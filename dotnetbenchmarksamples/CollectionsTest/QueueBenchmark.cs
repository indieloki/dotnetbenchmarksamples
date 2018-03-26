using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetbenchmarksamples.CollectionsTest
{
    [Config(typeof(MainConfig))]
    [BenchmarkCategory("Collections")]
    public class QueueBenchmark
    {
        private Queue<int> q = new Queue<int>();

        [Benchmark]
        public void Run()
        {
            q.Enqueue(0);
            q.Dequeue();
        }
    }
}
