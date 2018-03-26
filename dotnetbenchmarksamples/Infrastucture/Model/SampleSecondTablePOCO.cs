using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetbenchmarksamples.Infrastucture.Model
{
    public class SampleSecondTablePOCO
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public decimal Value { get; set; }
        public SampleFirstTablePOCO SampleFirstTablePOCO { get; set; }
    }
}
