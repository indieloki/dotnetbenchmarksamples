using dotnetbenchmarksamples.Infrastucture.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dotnetbenchmarksamples.Infrastucture.Data
{
    public static class DataSeeder<T> where T: DbContext, ISampleContext
    {
        public static void SeedDataUP(T context)
        {
            if (!context.SampleFirstTablePOCOs.Any())
            {
                var sampleSecondTablePOCOs = new List<SampleSecondTablePOCO> { };

                for (int i = 0; i < 100; i++)
                {
                    var firstPOCO = new SampleFirstTablePOCO {Name = "Parameter" + i };


                    for (int j = 0; j < 100; j++)
                    {
                        sampleSecondTablePOCOs.Add(new SampleSecondTablePOCO
                        {
                            SampleFirstTablePOCO = firstPOCO,
                            TimeStamp = DateTime.Now, Value = j
                        }
                        );
                    }
                }


                context.AddRange(sampleSecondTablePOCOs);
                context.SaveChanges();
            }
        }

        public static void SeedDataDown(T context)
        {
            var first = context.SampleFirstTablePOCOs;
            var second = context.SampleSecondTablePOCOs;

            context.SampleSecondTablePOCOs.RemoveRange(second);
            context.SampleFirstTablePOCOs.RemoveRange(first);

            context.SaveChanges();

        }
    }

}
