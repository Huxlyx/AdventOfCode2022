namespace AdventOfCode2022.Src
{
    public class Day10
    {
        private const string INPUT = "Res/Day10.txt";

        public static void RunDay10_1()
        {
            var lines = File.ReadAllLines(INPUT);
            List<int> strengths = SignalStrengthPerCycle(lines);
            Console.WriteLine(20 * strengths[19] + 60 * strengths[59] + 100 * strengths[99] + 140 * strengths[139] + 180 * strengths[179] + 220 * strengths[219]);
        }

        public static void RunDay10_2()
        {
            var lines = File.ReadAllLines(INPUT);

            List<int> strengths = SignalStrengthPerCycle(lines);

            for (int i = 0; i < strengths.Count; i++)
            {
                int posX = i % 40;
                if (i > 0 && i % 40 == 0)
                {
                    Console.WriteLine();
                }

                Console.Write((posX >= strengths[i] - 1 && posX <= strengths[i] + 1) ? '#' : '.');
            }
            Console.WriteLine();
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
