using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2022.Src
{
    public class Day09
    {
        private const string INPUT = "Res/Day09.txt";

        private record Pos(int x = 0, int y = 0);

        public static void RunDay09_1()
        {
            var lines = File.ReadAllLines(INPUT);

            Pos head = new(0, 0);
            Pos tail = new(0, 0);

            HashSet<Pos> visited = new()
            {
                tail
            };

            foreach (var line in lines)
            {
                var splits = line.Split(' ');
                int dist = int.Parse(splits[1]);

                /* move head */
                Pos target = splits[0][0] switch
                {
                    'U' => new(head.x, head.y + dist),
                    'D' => new(head.x, head.y - dist),
                    'L' => new(head.x - dist, head.y),
                    'R' => new(head.x + dist, head.y),
                    _ => throw new InvalidDataException(line),
                };

                Pos newHead = head;

                while (newHead != target)
                {
                    if (target.x != head.x)
                    {
                        newHead = new(target.x > head.x ? head.x + 1 : head.x - 1, head.y);
                    }
                    if (target.y != head.y)
                    {
                        newHead = new(head.x, target.y > head.y ? head.y + 1 : head.y - 1);
                    }
                    tail = MaybeMove(newHead, tail);
                    visited.Add(tail);
                    head = newHead;
                }
            }

            Console.WriteLine(visited.Count);
        }

        private static Pos MaybeMove(Pos lead, Pos follow)
        {
            if (lead == follow)
            {
                return follow;
            }

            var diffX = Math.Abs(lead.x - follow.x);
            var diffY = Math.Abs(lead.y - follow.y);

            if (lead.x == follow.x && diffY > 1)
            {
                return new(follow.x, lead.y > follow.y ? follow.y + 1 : follow.y - 1); /* tail moves up or down */
            }
            else if (lead.y == follow.y && diffX > 1)
            {
                return new(lead.x > follow.x ? follow.x + 1 : follow.x - 1, lead.y); /* tail moves left or right */
            }
            else if (diffX > 1 || diffY > 1)
            {
                return new(lead.x > follow.x ? follow.x + 1 : follow.x - 1, lead.y > follow.y ? follow.y + 1 : follow.y - 1); /* tail moves diagonal */
            }
            return follow;
        }


        public static void RunDay09_2()
        {
            var lines = File.ReadAllLines(INPUT);

            Pos[] chain = new Pos[] { new(), new(), new(), new(), new(), new(), new(), new(), new(), new() };

            HashSet<Pos> visited = new()
            {
                chain[^1]
            };

            foreach (var line in lines)
            {
                var splits = line.Split(' ');
                int dist = int.Parse(splits[1]);

                /* move head */
                Pos target = splits[0][0] switch
                {
                    'U' => new(chain[0].x, chain[0].y + dist),
                    'D' => new(chain[0].x, chain[0].y - dist),
                    'L' => new(chain[0].x - dist, chain[0].y),
                    'R' => new(chain[0].x + dist, chain[0].y),
                    _ => throw new InvalidDataException(line),
                };

                while (chain[0] != target)
                {
                    if (target.x != chain[0].x)
                    {
                        chain[0] = new(target.x > chain[0].x ? chain[0].x + 1 : chain[0].x - 1, chain[0].y);
                    }
                    if (target.y != chain[0].y)
                    {
                        chain[0] = new(chain[0].x, target.y > chain[0].y ? chain[0].y + 1 : chain[0].y - 1);
                    }

                    for (int i = 1; i < chain.Length; i++)
                    {
                        chain[i] = MaybeMove(chain[i - 1], chain[i]);
                    }
                    visited.Add(chain[^1]);
                }
            }

            Console.WriteLine(visited.Count);
        }
    }
}
