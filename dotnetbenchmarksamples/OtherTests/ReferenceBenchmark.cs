using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetbenchmarksamples.OtherTests
{
    [Config(typeof(MainConfig))]
    [BenchmarkCategory("Other")]
    public class ReferenceBenchmark
    {
        [Benchmark]
        public void Run()
        {
            var i = 1 + 1;
        }
    }
}
