
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2022.Src
{
    public class Day05
    {
        private const string INPUT = "Res/Day05.txt";

        private static Regex matchNumbers = new(@"(\d)+", RegexOptions.Compiled);

        public static void RunDay05_1()
        {
            var lines = File.ReadAllLines("Res/Day05.txt");
            List<string> startStacks = lines.TakeWhile(x => ! string.IsNullOrEmpty(x.Trim())).ToList();

            int stackCount = matchNumbers.Matches(startStacks[^1]).Count;
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

            PrintStacks(stacks);

            foreach (string line in lines.Skip(startStacks.Count + 1))
            {
                var matches = matchNumbers.Matches(line);
                /* get instructions */
                int moveCount = int.Parse(matches[0].Value);
                int src = int.Parse(matches[1].Value);
                int target = int.Parse(matches[2].Value);

                /* move string based */
                stacks[target - 1] = $"{stacks[target-1]}{string.Join("", stacks[src - 1][^moveCount..].Reverse().ToArray())}";
                stacks[src - 1] = stacks[src - 1][..^moveCount];
            }

            PrintStacks(stacks);

            foreach (string stack in stacks)
            {
                /* last char of each stack is the output */
                Console.Write(stack[^1]);
            }
            Console.WriteLine();
        }

        public static void RunDay05_2()
        {
            var lines = File.ReadAllLines("Res/Day05.txt");

            List<string> startStacks = lines.TakeWhile(x => !string.IsNullOrEmpty(x.Trim())).ToList();
            int stackCount = matchNumbers.Matches(startStacks[^1]).Count;
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

            PrintStacks(stacks);

            foreach (string line in lines.Skip(startStacks.Count + 1))
            {
                var matches = matchNumbers.Matches(line);
                /* get instructions */
                int moveCount = int.Parse(matches[0].Value);
                int src = int.Parse(matches[1].Value);
                int target = int.Parse(matches[2].Value);

                /* move string based */
                stacks[target - 1] = $"{stacks[target - 1]}{stacks[src - 1][^moveCount..]}";  /* <- do not reverse here */
                stacks[src - 1] = stacks[src - 1][..^moveCount];
            }

            PrintStacks(stacks);

            foreach (string stack in stacks)
            {
                /* last char of each stack is the output */
                Console.Write(stack[^1]);
            }
            Console.WriteLine();
        }


        private static void PrintStacks(string[] stacks)
        {
            int maxHeight = stacks.Max(x => x.Length);

            StringBuilder sb = new();
            for (int i = maxHeight - 1; i >= 0; --i)
            {
                for (int j = 0; j < stacks.Length; ++j)
                {
                    if (stacks[j].Length > i)
                    {
                        sb.Append($"[{stacks[j][i]}] ");
                    }
                    else
                    {
                        sb.Append("    ");
                    }

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
