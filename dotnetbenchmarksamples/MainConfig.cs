using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.CsProj;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetbenchmarksamples
{
    public class MainConfig : ManualConfig
    {
        public MainConfig()
        {
            Add(Job.Default.With(Runtime.Clr).With(Jit.RyuJit).With(Platform.X64).WithId("NET4.7_RyuJIT-x64"));
            Add(Job.Default.With(new MonoRuntime("Mono_x64", @"C:\Program Files\Mono\bin\mono.exe")));
            Add(Job.Default.With(Runtime.Core).With(CsProjCoreToolchain.NetCoreApp20).WithId("Core2.0-x64"));
            Add(RPlotExporter.Default);
            KeepBenchmarkFiles = true;
        }
    }

    public class MainConfigWitchOutMono : ManualConfig
    {
        public MainConfigWitchOutMono()
        {
            Add(Job.Default.With(Runtime.Clr).With(Jit.RyuJit).With(Platform.X64).WithId("NET4.7_RyuJIT-x64"));
            Add(Job.Default.With(Runtime.Core).With(CsProjCoreToolchain.NetCoreApp20).WithId("Core2.0-x64"));
            Add(RPlotExporter.Default);
            KeepBenchmarkFiles = true;
        }
    }
}
