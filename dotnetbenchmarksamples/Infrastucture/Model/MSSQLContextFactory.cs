using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace dotnetbenchmarksamples.Infrastucture.Model
{
    public class MSSQLContextFactory : IDesignTimeDbContextFactory<MSSQLContext>
    {
        public MSSQLContext CreateDbContext(string[] args)
        {
            

            var optionsBuilder = new DbContextOptionsBuilder<MSSQLContext>();
            var str = ConnectionStringFactory.GetMSString();
            optionsBuilder.UseSqlServer(str);

            return new MSSQLContext(optionsBuilder.Options);
        }
    }
}
