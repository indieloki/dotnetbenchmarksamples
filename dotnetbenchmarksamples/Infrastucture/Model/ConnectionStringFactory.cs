using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace dotnetbenchmarksamples.Infrastucture.Model
{
    public class ConnectionStringFactory
    {
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public static string GetMSString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(AssemblyDirectory).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            return configuration["ConnectionStrings:TestDb"];
        }

        public static string GetPostgreString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(AssemblyDirectory).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            return configuration["ConnectionStrings:TestDbPostgre"];
        }
    }
}
