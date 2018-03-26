using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace dotnetbenchmarksamples.Infrastucture.Model
{
    public class PostgreContextFactory : IDesignTimeDbContextFactory<PostgreContext>
    {
        public PostgreContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PostgreContext>();
            var str = ConnectionStringFactory.GetPostgreString();
            optionsBuilder.UseNpgsql(str);

            return new PostgreContext(optionsBuilder.Options);
        }
    }
}
