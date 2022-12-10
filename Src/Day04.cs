
namespace AdventOfCode2022.Src
{
    public class Day04 : IAoC
    {
        private const string INPUT = "Res/Day04.txt";

        public static void Part1()
        {
            var lines = File.ReadAllLines(INPUT);

            int fullRangesContained = 0;

            foreach (var line in lines)
            {
                string[] pair = line.Split(',');

                int start1 = int.Parse(pair[0][..pair[0].IndexOf('-')]);
                int end1 = int.Parse(pair[0][(pair[0].IndexOf('-') + 1)..]);

                int start2 = int.Parse(pair[1][..pair[1].IndexOf('-')]);
                int end2 = int.Parse(pair[1][(pair[1].IndexOf('-') + 1)..]);

                if ((start1 >= start2 && end1 <= end2) || (start2 >= start1 && end2 <= end1))
                {
                    fullRangesContained++;
                }
            }

#if DEBUG
            Console.WriteLine(fullRangesContained);
#endif
        }

        public static void Part2()
        {
            var lines = File.ReadAllLines(INPUT);

            int overlaps = 0;

            foreach (var line in lines)
            {
                string[] pair = line.Split(',');

                int start1 = int.Parse(pair[0][..pair[0].IndexOf('-')]);
                int end1 = int.Parse(pair[0][(pair[0].IndexOf('-') + 1)..]);

                int start2 = int.Parse(pair[1][..pair[1].IndexOf('-')]);
                int end2 = int.Parse(pair[1][(pair[1].IndexOf('-') + 1)..]);

                if (start1 <= end2 && end1 >= start2)
                {
                    overlaps++;
                }
            }

#if DEBUG
            Console.WriteLine(overlaps);
#endif
        }
    }
}
