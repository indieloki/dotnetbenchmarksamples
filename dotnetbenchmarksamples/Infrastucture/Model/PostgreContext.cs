using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetbenchmarksamples.Infrastucture.Model
{
    public class PostgreContext : DbContext, ISampleContext
    {
        public PostgreContext(DbContextOptions options) : base(options) { }

        public DbSet<SampleFirstTablePOCO> SampleFirstTablePOCOs { get; set; }
        public DbSet<SampleSecondTablePOCO> SampleSecondTablePOCOs { get; set; }

    }
}
