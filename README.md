# AoC 2022 🥳
## Benchmarks
```plain
BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19045.2251)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


|           Method |      Mean |    Error |    StdDev |    Median |
|----------------- |----------:|---------:|----------:|----------:|
| BenchmarkDay01_1 | 126.16 us | 2.480 us |  2.952 us | 124.67 us |
| BenchmarkDay01_2 | 130.54 us | 2.602 us |  5.136 us | 130.65 us |
| BenchmarkDay02_1 | 119.35 us | 2.280 us |  4.606 us | 117.39 us |
| BenchmarkDay02_2 | 118.72 us | 2.293 us |  2.900 us | 118.64 us |
| BenchmarkDay03_1 | 103.53 us | 2.051 us |  4.190 us | 103.77 us |
| BenchmarkDay03_2 | 115.77 us | 2.148 us |  4.086 us | 114.86 us |
| BenchmarkDay04_1 | 186.90 us | 3.700 us |  5.423 us | 185.74 us |
| BenchmarkDay04_2 | 178.82 us | 3.546 us |  3.483 us | 177.57 us |
| BenchmarkDay05_1 | 311.60 us | 5.996 us | 15.900 us | 309.60 us |
| BenchmarkDay05_2 | 234.08 us | 4.041 us |  3.582 us | 233.65 us |
| BenchmarkDay06_1 | 117.80 us | 0.860 us |  0.718 us | 117.88 us |
| BenchmarkDay06_2 | 565.33 us | 2.693 us |  2.387 us | 565.17 us |
| BenchmarkDay07_1 | 534.07 us | 1.424 us |  1.332 us | 534.00 us |
| BenchmarkDay07_2 | 529.82 us | 1.269 us |  1.187 us | 530.05 us |
| BenchmarkDay08_1 | 129.70 us | 1.546 us |  1.291 us | 129.73 us |
| BenchmarkDay08_2 | 229.66 us | 3.311 us |  2.765 us | 229.27 us |
| BenchmarkDay09_1 | 403.65 us | 7.854 us |  8.729 us | 400.70 us |
| BenchmarkDay09_2 | 435.19 us | 8.609 us |  9.212 us | 435.70 us |
| BenchmarkDay10_1 |  84.37 us | 1.676 us |  4.726 us |  82.46 us |
| BenchmarkDay10_2 |  81.53 us | 1.526 us |  2.421 us |  80.48 us |

// * Hints *
Outliers
  Benchmarks.BenchmarkDay01_1: Default -> 1 outlier  was  removed (140.72 us)
  Benchmarks.BenchmarkDay02_1: Default -> 1 outlier  was  removed (133.36 us)
  Benchmarks.BenchmarkDay03_2: Default -> 2 outliers were removed (128.76 us, 132.01 us)
  Benchmarks.BenchmarkDay04_1: Default -> 1 outlier  was  removed (213.10 us)
  Benchmarks.BenchmarkDay04_2: Default -> 1 outlier  was  removed (190.49 us)
  Benchmarks.BenchmarkDay05_1: Default -> 3 outliers were removed (358.95 us..406.48 us)
  Benchmarks.BenchmarkDay05_2: Default -> 1 outlier  was  removed (256.30 us)
  Benchmarks.BenchmarkDay06_1: Default -> 2 outliers were removed (120.58 us, 121.02 us)
  Benchmarks.BenchmarkDay06_2: Default -> 1 outlier  was  removed (574.05 us)
  Benchmarks.BenchmarkDay08_1: Default -> 2 outliers were removed (134.71 us, 138.77 us)
  Benchmarks.BenchmarkDay08_2: Default -> 2 outliers were removed (243.59 us, 244.48 us)
  Benchmarks.BenchmarkDay10_1: Default -> 6 outliers were removed (102.23 us..109.28 us)
  Benchmarks.BenchmarkDay10_2: Default -> 2 outliers were removed (89.26 us, 90.62 us)

// * Legends *
  Mean   : Arithmetic mean of all measurements
  Error  : Half of 99.9% confidence interval
  StdDev : Standard deviation of all measurements
  Median : Value separating the higher half of all measurements (50th percentile)
  1 us   : 1 Microsecond (0.000001 sec)
  ```