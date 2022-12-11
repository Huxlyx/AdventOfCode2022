# AoC 2022 🥳
## Benchmarks
```plain
BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19045.2251)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


|           Method |        Mean |    Error |   StdDev |
|----------------- |------------:|---------:|---------:|
| BenchmarkDay01_1 |   124.09 us | 0.934 us | 0.780 us |
| BenchmarkDay01_2 |   126.64 us | 1.461 us | 1.296 us |
| BenchmarkDay02_1 |   118.96 us | 2.288 us | 2.894 us |
| BenchmarkDay02_2 |   117.01 us | 0.425 us | 0.331 us |
| BenchmarkDay03_1 |    98.17 us | 0.697 us | 0.618 us |
| BenchmarkDay03_2 |   109.29 us | 0.706 us | 0.661 us |
| BenchmarkDay04_1 |   177.72 us | 1.030 us | 0.860 us |
| BenchmarkDay04_2 |   183.67 us | 3.547 us | 3.795 us |
| BenchmarkDay05_1 |   297.63 us | 5.914 us | 7.690 us |
| BenchmarkDay05_2 |   236.93 us | 4.475 us | 4.595 us |
| BenchmarkDay06_1 |   118.39 us | 2.164 us | 2.024 us |
| BenchmarkDay06_2 |   570.23 us | 4.621 us | 3.608 us |
| BenchmarkDay07_1 |   518.48 us | 1.781 us | 1.579 us |
| BenchmarkDay07_2 |   529.01 us | 3.418 us | 3.197 us |
| BenchmarkDay08_1 |   127.07 us | 0.633 us | 0.494 us |
| BenchmarkDay08_2 |   205.41 us | 2.585 us | 2.418 us |
| BenchmarkDay09_1 |   386.51 us | 2.415 us | 2.141 us |
| BenchmarkDay09_2 |   396.38 us | 3.237 us | 3.028 us |
| BenchmarkDay10_1 |    79.26 us | 0.634 us | 0.593 us |
| BenchmarkDay10_2 |    79.65 us | 0.983 us | 0.871 us |
| BenchmarkDay11_1 |   128.63 us | 1.007 us | 0.893 us |
| BenchmarkDay11_2 | 2,957.86 us | 8.217 us | 7.284 us |

// * Hints *
Outliers
  Benchmarks.BenchmarkDay01_1: Default -> 2 outliers were removed (129.49 us, 131.66 us)
  Benchmarks.BenchmarkDay01_2: Default -> 1 outlier  was  removed (130.80 us)
  Benchmarks.BenchmarkDay02_1: Default -> 1 outlier  was  removed (131.48 us)
  Benchmarks.BenchmarkDay02_2: Default -> 3 outliers were removed (119.16 us..120.36 us)
  Benchmarks.BenchmarkDay03_1: Default -> 1 outlier  was  removed (100.96 us)
  Benchmarks.BenchmarkDay04_1: Default -> 2 outliers were removed (183.23 us, 190.14 us)
  Benchmarks.BenchmarkDay05_1: Default -> 1 outlier  was  removed (335.82 us)
  Benchmarks.BenchmarkDay06_2: Default -> 3 outliers were removed, 4 outliers were detected (562.93 us, 584.61 us..600.40 us)
  Benchmarks.BenchmarkDay07_1: Default -> 1 outlier  was  removed (526.58 us)
  Benchmarks.BenchmarkDay08_1: Default -> 3 outliers were removed, 5 outliers were detected (125.98 us, 126.31 us, 128.73 us..129.85 us)
  Benchmarks.BenchmarkDay09_1: Default -> 1 outlier  was  removed (402.31 us)
  Benchmarks.BenchmarkDay10_1: Default -> 1 outlier  was  detected (78.08 us)
  Benchmarks.BenchmarkDay10_2: Default -> 1 outlier  was  removed (82.53 us)
  Benchmarks.BenchmarkDay11_1: Default -> 1 outlier  was  removed (132.87 us)
  Benchmarks.BenchmarkDay11_2: Default -> 1 outlier  was  removed, 2 outliers were detected (2.94 ms, 2.98 ms)


// * Legends *
  Mean   : Arithmetic mean of all measurements
  Error  : Half of 99.9% confidence interval
  StdDev : Standard deviation of all measurements
  Median : Value separating the higher half of all measurements (50th percentile)
  1 us   : 1 Microsecond (0.000001 sec)
  ```