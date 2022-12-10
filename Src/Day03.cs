
namespace AdventOfCode2022.Src
{
    public class Day03 : IAoC
    {
        public static void Part1()
        {
            var lines = File.ReadAllLines("Res/Day03.txt");

            long sumOfPriorities = 0;

            foreach (string line in lines)
            {
                string compartment1 = line[..(line.Length / 2)];
                string compartment2 = line[(line.Length / 2)..];

                foreach (char item in compartment1)
                {
                    if (compartment2.Contains(item))
                    {
                        /* add value of "items" contained in both, the lower and upper half of the input string */
                        sumOfPriorities += char.IsLower(item) ? (item - 'a' + 1) : (item - 'A' + 27);
                        break;
                    }
                }
            }

#if DEBUG
            Console.WriteLine(sumOfPriorities);
#endif
        }

        public static void Part2()
        {
            var lines = File.ReadAllLines("Res/Day03.txt");

            long sumOfBadges = 0;

            for (int i = 0; i < lines.Length; i += 3)
            {
                char[] itms1 = lines[i].ToCharArray();
                char[] dupl1 = itms1.Where(x => lines[i + 1].Contains(x)).ToArray(); /* items that appear in 1st and 2nd string */
                char   dupl2 = dupl1.Where(x => lines[i + 2].Contains(x)).First();   /* item(!) that appears in all 3 strings */

                sumOfBadges += char.IsLower(dupl2) ? (dupl2 - 'a' + 1) : (dupl2 - 'A' + 27);
            }

#if DEBUG
            Console.WriteLine(sumOfBadges);
#endif
        }
    }
}
