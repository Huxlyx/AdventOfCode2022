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
| BenchmarkDay06_2 |   180.70 us | 0.47 us  | 0.400 us |
| BenchmarkDay07_1 |   518.48 us | 1.781 us | 1.579 us |
| BenchmarkDay07_2 |   529.01 us | 3.418 us | 3.197 us |
| BenchmarkDay08_1 |   127.07 us | 0.633 us | 0.494 us |
| BenchmarkDay08_2 |   205.41 us | 2.585 us | 2.418 us |
| BenchmarkDay09_1 |   379.36 us | 1.785 us | 1.669 us |
| BenchmarkDay09_2 |   370.04 us | 1.199 us | 1.121 us |
| BenchmarkDay10_1 |    79.26 us | 0.634 us | 0.593 us |
| BenchmarkDay10_2 |    79.65 us | 0.983 us | 0.871 us |
| BenchmarkDay11_1 |   128.63 us | 1.007 us | 0.893 us |
| BenchmarkDay11_2 | 2,957.86 us | 8.217 us | 7.284 us |


// * Legends *
  Mean   : Arithmetic mean of all measurements
  Error  : Half of 99.9% confidence interval
  StdDev : Standard deviation of all measurements
  Median : Value separating the higher half of all measurements (50th percentile)
  1 us   : 1 Microsecond (0.000001 sec)
  ```