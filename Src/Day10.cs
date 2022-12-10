namespace AdventOfCode2022.Src
{
    public class Day10 : IAoC
    {
        private const string INPUT = "Res/Day10.txt";

        public static void Part1()
        {
            var lines = File.ReadAllLines(INPUT);
            List<int> strengths = SignalStrengthPerCycle(lines);
            int result = 20 * strengths[19] + 60 * strengths[59] + 100 * strengths[99] + 140 * strengths[139] + 180 * strengths[179] + 220 * strengths[219];
#if DEBUG
            Console.WriteLine(result);
#endif
        }

        public static void Part2()
        {
            var lines = File.ReadAllLines(INPUT);

            List<int> strengths = SignalStrengthPerCycle(lines);

            for (int i = 0; i < strengths.Count; i++)
            {
                int posX = i % 40;
                if (i > 0 && i % 40 == 0)
                {
#if DEBUG
                    Console.WriteLine();
#endif
                }

#if DEBUG
                Console.Write((posX >= strengths[i] - 1 && posX <= strengths[i] + 1) ? '#' : '.');
#endif
            }
        }

        private static List<int> SignalStrengthPerCycle(string[] input)
        {
            List<int> strengths = new();
            int regX = 1;

            foreach (var line in input)
            {
                strengths.Add(regX);
                if (line == "noop")
                {
                    continue;
                }
                strengths.Add(regX);
                regX += int.Parse(line.Split(' ')[1]);
            }
            return strengths;
        }
    }
}
