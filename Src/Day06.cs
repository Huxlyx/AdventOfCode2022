
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2022.Src
{
    public class Day06
    {
        private const string INPUT = "Res/Day06.txt";

        private static Regex matchNumbers = new(@"(\d)+", RegexOptions.Compiled);

        public static void RunDay06_1()
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
                    Console.WriteLine(i + 1);
                    break;
                }
            }

            Console.WriteLine();
        }

        public static void RunDay06_2()
        {
            var lines = File.ReadAllLines(INPUT);
            string data = lines[0]; /* one datastream */
            char[] chars = data.ToCharArray();

            for (int i = 13; i < chars.Length; i++)
            {
                HashSet<char> set = new()
                {
                    chars[i - 13],
                    chars[i - 12],
                    chars[i - 11],
                    chars[i - 10],
                    chars[i - 9],
                    chars[i - 8],
                    chars[i - 7],
                    chars[i - 6],
                    chars[i - 5],
                    chars[i - 4],
                    chars[i - 3],
                    chars[i - 2],
                    chars[i - 1],
                    chars[i]
                };

                if (set.Count == 14)
                {
                    Console.WriteLine(i + 1);
                    break;
                }
            }

            Console.WriteLine();
        }
    }
}
