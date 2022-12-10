using AdventOfCode2022.Src;
using BenchmarkDotNet.Running;
using System.Diagnostics;

Stopwatch sw = new();
sw.Start();
Day10.Part2();
Console.WriteLine("Done after " + sw.Elapsed);

BenchmarkRunner.Run<Benchmarks>();