using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dotnetbenchmarksamples.Migrations.MSSQL
{
    public partial class AddGetFirtsProc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROC GetFirstById @ID bigint   
                    AS 
                    BEGIN
                    SELECT [Id],[Name]
                      FROM [TestDb].[dbo].[SampleFirstTablePOCOs]
                      where ID = @ID
                    END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DELETE PROC GetFirstById";
            migrationBuilder.Sql(sp);
        }
    }
}
