using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetbenchmarksamples.Infrastucture.Model
{
    public interface ISampleContext
    {
        DbSet<SampleFirstTablePOCO> SampleFirstTablePOCOs { get; set; }
        DbSet<SampleSecondTablePOCO> SampleSecondTablePOCOs { get; set; }
    }
}
