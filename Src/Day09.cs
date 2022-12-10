
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Runtime.CompilerServices;

namespace AdventOfCode2022.Src
{
    /// <summary>
    /// Optimizations:
    ///baseline
    ///|           Method |       Mean |    Error |   StdDev |
    ///|----------------- |-----------:|---------:|---------:|
    ///| BenchmarkDay09_1 |   883.2 us | 12.76 us |  9.97 us |
    ///| BenchmarkDay09_2 | 1,631.4 us | 16.82 us | 14.91 us |
    ///
    ///Aggressive inlining
    ///|           Method |       Mean |    Error |   StdDev |
    ///|----------------- |-----------:|---------:|---------:|
    ///| BenchmarkDay09_1 |   865.6 us | 13.06 us | 11.58 us |
    ///| BenchmarkDay09_2 | 1,518.9 us |  6.11 us |  5.41 us |
    ///
    ///Structs instead of Records
    ///|           Method |     Mean |     Error |    StdDev |
    ///|----------------- |---------:|----------:|----------:|
    ///| BenchmarkDay09_1 | 1.212 ms | 0.0153 ms | 0.0143 ms |
    ///| BenchmarkDay09_2 | 1.020 ms | 0.0030 ms | 0.0027 ms |
    ///
    ///removed allocations & HashSet of tuple instead of struct (part 2)
    ///|           Method |       Mean |    Error |   StdDev |
    ///|----------------- |-----------:|---------:|---------:|
    ///| BenchmarkDay09_1 | 1,206.9 us | 13.86 us | 12.28 us |
    ///| BenchmarkDay09_2 |   693.0 us |  4.41 us |  3.91 us |
    ///
    ///HashSet of tuple instead of struct (part 1)
    ///|           Method |     Mean |   Error |  StdDev |
    ///|----------------- |---------:|--------:|--------:|
    ///| BenchmarkDay09_1 | 422.9 us | 6.41 us | 6.00 us |
    ///| BenchmarkDay09_2 | 635.6 us | 6.05 us | 5.66 us |
    ///
    ///Break move chain as soon as part didn't move (part 2)
    ///|           Method |     Mean |   Error |  StdDev |
    ///|----------------- |---------:|--------:|--------:|
    ///| BenchmarkDay09_1 | 421.1 us | 3.95 us | 3.69 us |
    ///| BenchmarkDay09_2 | 422.5 us | 1.80 us | 1.68 us |
    ///
    ///Only add position to set if tail moved
    ///|           Method |     Mean |   Error |  StdDev |
    ///|----------------- |---------:|--------:|--------:|
    ///| BenchmarkDay09_1 | 400.2 us | 2.80 us | 2.48 us |
    ///| BenchmarkDay09_2 | 412.9 us | 2.78 us | 2.32 us |
    /// </summary>
    public class Day09 : IAoC
    {
        private const string INPUT = "Res/Day09.txt";

        private struct Pos
        {
            public Pos(int x, int y)
            {
                X = x; 
                Y = y;
            }
            public int X;
            public int Y;
        }

        public static void Part1()
        {
            var lines = File.ReadAllLines(INPUT);

            Pos head = new();
            Pos tail = new();
            Pos target = new();

            HashSet<(int, int)> visited = new()
            {
                (tail.X, tail.Y)
            };

            foreach (var line in lines)
            {
                int dist = int.Parse(line[2..]);

                /* move head */
                switch (line[0])
                {
                    case 'U':
                        target.Y = head.Y + dist;
                        break;
                    case 'D':
                        target.Y = head.Y - dist;
                        break;
                    case 'L':
                        target.X = head.X - dist;
                        break;
                    case 'R':
                        target.X = head.X + dist;
                        break;
                }

                while (head.X != target.X || head.Y != target.Y)
                {
                    if (target.X != head.X)
                    {
                        head.X += target.X > head.X ?  1 :  -1;
                    } 
                    else 
                    {
                        head.Y += target.Y > head.Y ? 1 : -1;
                    }
                    if (MaybeMove(head, ref tail))
                    {
                        visited.Add((tail.X, tail.Y));
                    }
                }
            }

#if DEBUG
            Console.WriteLine(visited.Count);
#endif
        }

        public static void Part2()
        {
            var lines = File.ReadAllLines(INPUT);

            Pos[] chain = new Pos[] { new(), new(), new(), new(), new(), new(), new(), new(), new(), new() };
            Pos target = new();

            HashSet<(int ,int)> visited = new()
            {
                (chain[^1].X, chain[^1].Y)
            };

            foreach (var line in lines)
            {
                int dist = int.Parse(line[2..]);

                /* move head */
                switch (line[0])
                {
                    case 'U':
                        target.Y = chain[0].Y + dist;
                        break;
                    case 'D':
                        target.Y = chain[0].Y - dist;
                        break;
                    case 'L':
                        target.X = chain[0].X - dist;
                        break;
                    case 'R':
                        target.X = chain[0].X + dist;
                        break;
                }

                while (chain[0].X != target.X || chain[0].Y != target.Y)
                {
                    if (target.X != chain[0].X)
                    {
                        chain[0].X += target.X > chain[0].X ? 1 : -1;
                    }
                    else
                    {
                        chain[0].Y += target.Y > chain[0].Y ?  1 :  -1;
                    }

                    bool tailDidMove = false;
                    for (int i = 1; i < chain.Length; i++)
                    {
                        if ( ! MaybeMove(chain[i - 1], ref chain[i]))
                        {
                            break;
                        }
                        tailDidMove = true;
                    }
                    if (tailDidMove)
                    {
                        visited.Add((chain[^1].X, chain[^1].Y));
                    }
                }
            }

#if DEBUG
            Console.WriteLine(visited.Count);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool MaybeMove(Pos lead, ref Pos follow)
        {
            if (lead.X == follow.X && lead.Y == follow.Y)
            {
                return true;
            }

            var diffX = Math.Abs(lead.X - follow.X);
            var diffY = Math.Abs(lead.Y - follow.Y);

            if (diffX > 1 || diffY > 1)
            {
                if (lead.X == follow.X && diffY > 1)
                {
                    /* tail move up or down */
                    follow.Y += lead.Y > follow.Y ? 1 : -1;
                    return true;
                }
                else if (lead.Y == follow.Y)
                {
                    /* tail move left or right */
                    follow.X += lead.X > follow.X ? 1 : -1;
                    return true;
                }
                else
                {
                    /* tail move diagonal */
                    follow.X += lead.X > follow.X ? 1 : -1;
                    follow.Y += lead.Y > follow.Y ? 1 : -1;
                    return true;
                }
            }
            return false;
        }
    }
}
