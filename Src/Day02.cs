using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Src
{
    public class Day02 : IAoC
    {
        public static void Part1()
        {
            /* only 9 possible outcomes 
                A X = 3 + 1
                A Y = 6 + 2
                A Z = 0 + 3
                B X = 0 + 1
                B Y = 3 + 2
                B Z = 6 + 3
                C X = 6 + 1
                C Y = 0 + 2
                C Z = 3 + 3 */
            var lines = File.ReadAllLines("Res/Day02.txt");
            int score = 0;

            foreach (string line in lines)
            {
                switch (line)
                {
                    case "B X":
                        score += 1;
                        break;
                    case "C Y":
                        score += 2;
                        break;
                    case "A Z":
                        score += 3;
                        break;
                    case "A X":
                        score += 4;
                        break;
                    case "B Y":
                        score += 5;
                        break;
                    case "C Z":
                        score += 6;
                        break;
                    case "C X":
                        score += 7;
                        break;
                    case "A Y":
                        score += 8;
                        break;
                    case "B Z":
                        score += 9;
                        break;
                    default:
                        Console.WriteLine($"unexpected {line}");
                        break;
                }
            }
#if DEBUG
            Console.WriteLine(score);
#endif
        }

        public static void Part2()
        {
            /* only 9 possible outcomes 
                A X = 0 + 3
                A Y = 3 + 1
                A Z = 6 + 2
                B X = 0 + 1
                B Y = 3 + 2
                B Z = 6 + 3
                C X = 0 + 2
                C Y = 3 + 3
                C Z = 6 + 1 */
            var lines = File.ReadAllLines("Res/Day02.txt");
            int score = 0;

            foreach (string line in lines)
            {
                switch (line)
                {
                    case "B X":
                        score += 1;
                        break;
                    case "C X":
                        score += 2;
                        break;
                    case "A X":
                        score += 3;
                        break;
                    case "A Y":
                        score += 4;
                        break;
                    case "B Y":
                        score += 5;
                        break;
                    case "C Y":
                        score += 6;
                        break;
                    case "C Z":
                        score += 7;
                        break;
                    case "A Z":
                        score += 8;
                        break;
                    case "B Z":
                        score += 9;
                        break;
                    default:
                        Console.WriteLine($"unexpected {line}");
                        break;
                }
            }

#if DEBUG
            Console.WriteLine(score);
#endif
        }

    }
}
