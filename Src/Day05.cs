
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2022.Src
{
    public partial class Day05 : IAoC
    {
        private const string INPUT = "Res/Day05.txt";

        [GeneratedRegex("(\\d)+", RegexOptions.Compiled)]
        private static partial Regex MatchNumber();

        public static void Part1()
        {
            var lines = File.ReadAllLines(INPUT);

            List<string> startStacks = lines.TakeWhile(x => ! string.IsNullOrEmpty(x.Trim())).ToList();
            string[] stacks = PrepareStacks(startStacks);

#if DEBUG
            PrintStacks(stacks);
#endif

            foreach (string line in lines.Skip(startStacks.Count + 1))
            {
                /* get instructions */
                var matches = MatchNumber().Matches(line);
                int moveCount = int.Parse(matches[0].Value);
                int src = int.Parse(matches[1].Value);
                int target = int.Parse(matches[2].Value);

                /* move string based */
                stacks[target - 1] = $"{stacks[target-1]}{string.Join("", stacks[src - 1][^moveCount..].Reverse().ToArray())}";
                stacks[src - 1] = stacks[src - 1][..^moveCount];
            }

#if DEBUG
            PrintStacks(stacks);

            /* last char of each stack is the output */
            stacks.ToList().ForEach(x => Console.Write(x[^1]));

            Console.WriteLine();
#endif
        }

        public static void Part2()
        {
            var lines = File.ReadAllLines(INPUT);

            List<string> startStacks = lines.TakeWhile(x => !string.IsNullOrEmpty(x.Trim())).ToList();
            string[] stacks = PrepareStacks(startStacks);

            foreach (string line in lines.Skip(startStacks.Count + 1))
            {
                /* get instructions */
                var matches = MatchNumber().Matches(line);
                int moveCount = int.Parse(matches[0].Value);
                int src = int.Parse(matches[1].Value);
                int target = int.Parse(matches[2].Value);

                /* move string based */
                stacks[target - 1] = $"{stacks[target - 1]}{stacks[src - 1][^moveCount..]}";  /* <- do not reverse here */
                stacks[src - 1] = stacks[src - 1][..^moveCount];
            }

#if DEBUG
            PrintStacks(stacks);

            /* last char of each stack is the output */
            stacks.ToList().ForEach(x => Console.Write(x[^1]));

            Console.WriteLine();
#endif
        }

        private static string[] PrepareStacks(List<string> startStacks)
        {
            int stackCount = MatchNumber().Matches(startStacks[^1]).Count;
            string[] stacks = new string[stackCount];

            for (int i = 0; i < startStacks.Count - 1; ++i)
            {
                for (int j = 0; j < stackCount; ++j)
                {
                    char item = startStacks[i][j * 4 + 1];
                    if (item != ' ')
                    {
                        stacks[j] = item + stacks[j];
                    }
                }
            }
            return stacks;
        }


        private static void PrintStacks(string[] stacks)
        {
            int maxHeight = stacks.Max(x => x.Length);

            StringBuilder sb = new();
            for (int i = maxHeight - 1; i >= 0; --i)
            {
                for (int j = 0; j < stacks.Length; ++j)
                {
                    sb.Append(stacks[j].Length > i ? $"[{stacks[j][i]}] " : "    ");
                }
                sb.AppendLine();
            }

            sb.Append(' ');
            for (int i = 1; i <= stacks.Length; ++i)
            {
                sb.Append(i).Append("   ");
            }
            
            Console.WriteLine(sb.AppendLine().ToString());
        }
    }
}
