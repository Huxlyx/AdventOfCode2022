
namespace AdventOfCode2022.Src
{
    /// <summary>
    /// Optimizations:
    ///baseline
    ///|           Method |     Mean |   Error |  StdDev |
    ///|----------------- |---------:|--------:|--------:|
    ///| BenchmarkDay06_1 | 115.6 us | 1.07 us | 1.00 us |
    ///| BenchmarkDay06_2 | 572.4 us | 3.43 us | 3.21 us |
    ///
    ///Check if set contains before inserting, potentially skipping lots of inserts
    ///|           Method |     Mean |   Error |  StdDev |
    ///|----------------- |---------:|--------:|--------:|
    ///| BenchmarkDay06_1 | 117.0 us | 1.08 us | 0.95 us |
    ///| BenchmarkDay06_2 | 180.7 us | 0.47 us | 0.40 us |
    /// </summary>
    public class Day06 : IAoC
    {
        private const string INPUT = "Res/Day06.txt";

        public static void Part1()
        {
            var lines = File.ReadAllLines(INPUT);
            string data = lines[0]; /* one datastream */
            char[] chars = data.ToCharArray();

            for (int i = 3; i < chars.Length; i++)
            {
                HashSet<char> set = new()
                {
                    chars[i - 3],
                    chars[i - 2],
                    chars[i - 1],
                    chars[i]
                };

                if (set.Count == 4)
                {
#if DEBUG
                    Console.WriteLine(i + 1);
#endif
                    break;
                }
            }
        }

        public static void Part2()
        {
            var lines = File.ReadAllLines(INPUT);
            string data = lines[0]; /* one datastream */
            char[] chars = data.ToCharArray();
            HashSet<char> set = new(14);

            for (int i = 13; i < chars.Length; i++)
            {
                set.Add(chars[i]);
                for (int j = 1; j < 14; ++j)
                {
                    if (set.Contains(chars[i - j]))
                    {
                        break;
                    }
                    set.Add(chars[i - j]);
                }

                if (set.Count == 14)
                {
#if DEBUG
                    Console.WriteLine(i + 1);
#endif
                    break;
                }
                set.Clear();
            }
        }
    }
}
