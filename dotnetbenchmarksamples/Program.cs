using BenchmarkDotNet.Running;
using dotnetbenchmarksamples.Infrastucture.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;

namespace dotnetbenchmarksamples
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).GetTypeInfo().Assembly).Run(args);

        }
    }
}
