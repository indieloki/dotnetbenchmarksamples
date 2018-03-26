using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using dotnetbenchmarksamples.Infrastucture.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using Npgsql;
using Microsoft.EntityFrameworkCore;

namespace dotnetbenchmarksamples.DatabaseTests
{
    [Config(typeof(MainConfigWitchOutMono))]
    [BenchmarkCategory("Database")]
    public class Select1
    {
        public Random Random = new Random(DateTime.Now.Millisecond);
        public long Index { get { return Random.Next(100); } }

        [Benchmark]
        public void MsEfFind()
        {
            SampleFirstTablePOCO firstItem;
            using (var db = new MSSQLContextFactory().CreateDbContext(null))
            {
                firstItem = db.SampleFirstTablePOCOs.Find(Index);
            }
        }

        [Benchmark]
        public void PostgreEfFind()
        {
            SampleFirstTablePOCO firstItem;
            using (var db = new PostgreContextFactory().CreateDbContext(null))
            {
                firstItem = db.SampleFirstTablePOCOs.Find(Index);
            }
        }

        [Benchmark]
        public void MsAdoSelect1()
        {
            DataTable dt = new DataTable();
            // just doing this cause dr.load fails
            dt.Columns.Add("Id");
            dt.Columns.Add("Name");

            SampleFirstTablePOCO firstItem;

            using (var connection = new SqlConnection(ConnectionStringFactory.GetMSString()))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = 
                        @"SELECT [Id],[Name] FROM [TestDb].[dbo].[SampleFirstTablePOCOs] where Id = " + Index.ToString();

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);

                    var retList = new List<SampleFirstTablePOCO>();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var row = dt.Rows[i];

                        var temp = new SampleFirstTablePOCO()
                        {
                            Id = Convert.ToInt64(row["Id"].ToString()),
                            Name = row["Name"].ToString()
                        };

                        retList.Add(temp);
                    }

                    firstItem = retList.FirstOrDefault();

                }
                connection.Close();
            }
        }

        [Benchmark]
        public void PostgreNpgsqlSelect1()
        {
            DataTable dt = new DataTable();
            // just doing this cause dr.load fails
            dt.Columns.Add("Id");
            dt.Columns.Add("Name");

            SampleFirstTablePOCO firstItem;

            using (var connection = new NpgsqlConnection(ConnectionStringFactory.GetPostgreString()))
            {
                connection.Open();

                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        "SELECT \"Id\", \"Name\" FROM public.\"SampleFirstTablePOCOs\" WHERE  public.\"SampleFirstTablePOCOs\".\"Id\" = " + Index.ToString();

                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
                    da.Fill(dt);

                    var retList = new List<SampleFirstTablePOCO>();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var row = dt.Rows[i];

                        var temp = new SampleFirstTablePOCO()
                        {
                            Id = Convert.ToInt64(row["Id"].ToString()),
                            Name = row["Name"].ToString()
                        };

                        retList.Add(temp);
                    }

                    firstItem = retList.FirstOrDefault();

                }
                connection.Close();
            }
        }

        [Benchmark]
        public void MsEfFromProcedure()
        {
            SampleFirstTablePOCO firstItem;
            var param = new SqlParameter("@Id", Index);

            using (var db = new MSSQLContextFactory().CreateDbContext(null))
            {
                firstItem = db.SampleFirstTablePOCOs.FromSql("GetFirstById @Id", param).FirstOrDefault();
            }
        }

        [Benchmark]
        public void PostgreEfFromProcedure()
        {
            SampleFirstTablePOCO firstItem;
            var param = new NpgsqlParameter("@Id", Index);

            using (var db = new PostgreContextFactory().CreateDbContext(null))
            {
                firstItem = db.SampleFirstTablePOCOs.FromSql("select * from public.\"GetFirtsById\" (@Id)", param).FirstOrDefault();
            }
        }

    }
}
