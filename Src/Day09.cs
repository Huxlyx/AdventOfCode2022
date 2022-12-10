
namespace AdventOfCode2022.Src
{
    public class Day09 : IAoC
    {
        private const string INPUT = "Res/Day09.txt";

        private record Pos(int X = 0, int Y = 0);

        public static void Part1()
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
                    'U' => new(head.X, head.Y + dist),
                    'D' => new(head.X, head.Y - dist),
                    'L' => new(head.X - dist, head.Y),
                    'R' => new(head.X + dist, head.Y),
                    _ => throw new InvalidDataException(line),
                };

                Pos newHead = head;

                while (newHead != target)
                {
                    if (target.X != head.X)
                    {
                        newHead = new(target.X > head.X ? head.X + 1 : head.X - 1, head.Y);
                    }
                    if (target.Y != head.Y)
                    {
                        newHead = new(head.X, target.Y > head.Y ? head.Y + 1 : head.Y - 1);
                    }
                    tail = MaybeMove(newHead, tail);
                    visited.Add(tail);
                    head = newHead;
                }
            }

#if DEBUG
            Console.WriteLine(visited.Count);
#endif
        }

        private static Pos MaybeMove(Pos lead, Pos follow)
        {
            if (lead == follow)
            {
                return follow;
            }

            var diffX = Math.Abs(lead.X - follow.X);
            var diffY = Math.Abs(lead.Y - follow.Y);

            if (lead.X == follow.X && diffY > 1)
            {
                return new(follow.X, lead.Y > follow.Y ? follow.Y + 1 : follow.Y - 1); /* tail moves up or down */
            }
            else if (lead.Y == follow.Y && diffX > 1)
            {
                return new(lead.X > follow.X ? follow.X + 1 : follow.X - 1, lead.Y); /* tail moves left or right */
            }
            else if (diffX > 1 || diffY > 1)
            {
                return new(lead.X > follow.X ? follow.X + 1 : follow.X - 1, lead.Y > follow.Y ? follow.Y + 1 : follow.Y - 1); /* tail moves diagonal */
            }
            return follow;
        }


        public static void Part2()
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
                    'U' => new(chain[0].X, chain[0].Y + dist),
                    'D' => new(chain[0].X, chain[0].Y - dist),
                    'L' => new(chain[0].X - dist, chain[0].Y),
                    'R' => new(chain[0].X + dist, chain[0].Y),
                    _ => throw new InvalidDataException(line),
                };

                while (chain[0] != target)
                {
                    if (target.X != chain[0].X)
                    {
                        chain[0] = new(target.X > chain[0].X ? chain[0].X + 1 : chain[0].X - 1, chain[0].Y);
                    }
                    if (target.Y != chain[0].Y)
                    {
                        chain[0] = new(chain[0].X, target.Y > chain[0].Y ? chain[0].Y + 1 : chain[0].Y - 1);
                    }

                    for (int i = 1; i < chain.Length; i++)
                    {
                        chain[i] = MaybeMove(chain[i - 1], chain[i]);
                    }
                    visited.Add(chain[^1]);
                }
            }

#if DEBUG
            Console.WriteLine(visited.Count);
#endif
        }
    }
}
