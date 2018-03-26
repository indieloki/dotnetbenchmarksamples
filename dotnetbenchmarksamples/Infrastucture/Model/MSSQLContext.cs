using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace dotnetbenchmarksamples.Infrastucture.Model
{
    public class MSSQLContext : DbContext, ISampleContext
    {
        public MSSQLContext(DbContextOptions options) : base(options) { }

        public DbSet<SampleFirstTablePOCO> SampleFirstTablePOCOs { get; set; }
        public DbSet<SampleSecondTablePOCO> SampleSecondTablePOCOs { get; set; }

    }
}
