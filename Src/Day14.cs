using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace AdventOfCode2022.Src
{
    public class Day14 : IAoC
    {
        private const string INPUT = "Res/Day14.txt";

        private const char ROCK = '#';
        private const char SAND = 'O';
        private const char AIR =  '.';


        private class RockPathPart
        {
            public int posX { get; init; }
            public int posY { get; init; }

            public RockPathPart? next { get; set; }

            public static RockPathPart Parse(string input)
            {
                int[] coords = input.Split(',').Select(x => int.Parse(x)).ToArray();
                return new RockPathPart()
                {
                    posX = coords[0],
                    posY = coords[1]
                };
            }

            public void AddPath(char[][] grid, int minX, int maxX)
            {
                if (next != null)
                {

                    if (posX != next.posX)
                    {
                        if (posX < next.posX)
                        {
                            for (int i = posX; i <= next.posX; ++i)
                            {
                                grid[posY][i - minX] = ROCK;
                            }
                        }
                        else
                        {
                            for (int i = next.posX; i <= posX; ++i)
                            {
                                grid[posY][i - minX] = ROCK;
                            }

                        }
                    }
                    else
                    {
                        if (posY < next.posY)
                        {
                            for (int i = posY; i <= next.posY; ++i)
                            {
                                grid[i][posX - minX] = ROCK;
                            }
                        }
                        else
                        {
                            for (int i = next.posY; i <= posY; ++i)
                            {
                                grid[i][posX - minX] = ROCK;
                            }
                        }
                    }

                    next.AddPath(grid, minX, maxX);
                }
            }
        }

        public static void Part1()
        {
            var lines = File.ReadAllLines(INPUT);

            List<RockPathPart> paths = new();

            int minX = int.MaxValue;
            int maxX = 0;
            int maxY = 0;

            foreach (var line in lines)
            {
                var parts = line.Split(" -> ");

                RockPathPart pathStart = RockPathPart.Parse(parts[0]);
                RockPathPart current = pathStart;
                paths.Add(pathStart);

                if (minX > current.posX)
                {
                    minX = current.posX;
                }

                if (maxX < current.posX)
                {
                    maxX = current.posX;
                }

                if (maxY < current.posY)
                {
                    maxY = current.posY;
                }

                for (int i = 1; i < parts.Length; ++i)
                {
                    RockPathPart part = RockPathPart.Parse(parts[i]);
                    current.next = part;
                    current = part;

                    if (minX > current.posX)
                    {
                        minX = current.posX;
                    }

                    if (maxX < current.posX)
                    {
                        maxX = current.posX;
                    }

                    if (maxY < current.posY)
                    {
                        maxY = current.posY;
                    }
                }
            }

            char[][] grid = new char[maxY][];
            for (int i = 0; i < grid.Length; ++i)
            {
                grid[i] = new String(AIR, maxX - minX + 1).ToCharArray();
            }

            paths.ForEach(p => p.AddPath(grid, minX, maxX));

            /* simluate sand */
            bool canMove = true;
            int sandCount = 0;
            while (canMove)
            {
                bool inMotion = true;
                (int x, int y) = (500, 0);
                ++sandCount;
                while (inMotion)
                {
                    try
                    {
                        if (grid[y + 1][x - minX] == AIR)
                        {
                            y += 1;
                            continue;
                        }
                        else
                        {
                            /* path below is blocked */
                            if (grid[y + 1][x - minX - 1] == AIR) /* check diagonal left */
                            {
                                x -= 1;
                                y += 1;
                                continue;
                            }
                            else if (grid[y + 1][x - minX + 1] == AIR) /* check diagonal right */
                            {
                                x += 1;
                                y += 1;
                                continue;
                            }
                            else
                            {
                                grid[y][x - minX] = SAND;
                                inMotion = false;
                            }

                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        inMotion = false;
                        canMove = false;
                    }
                }
            }

#if DEBUG
            PrintGrid(grid);
            Console.WriteLine(sandCount - 1);
#endif
        }

        private static void PrintGrid(char[][] grid)
        {
            StringBuilder sb = new();
            foreach (var line in grid)
            {
                foreach (char c in line)
                {
                    sb.Append(c);
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());
            File.WriteAllText("C:/temp/aoc22_14.txt", sb.ToString());
        }


        public static void Part2()
        {
            var lines = File.ReadAllLines(INPUT);

            List<RockPathPart> paths = new();

            int minX = int.MaxValue;
            int maxX = 0;
            int maxY = 0;

            foreach (var line in lines)
            {
                var parts = line.Split(" -> ");

                RockPathPart pathStart = RockPathPart.Parse(parts[0]);
                RockPathPart current = pathStart;
                paths.Add(pathStart);

                if (minX > current.posX)
                {
                    minX = current.posX;
                }

                if (maxX < current.posX)
                {
                    maxX = current.posX;
                }

                if (maxY < current.posY)
                {
                    maxY = current.posY;
                }

                for (int i = 1; i < parts.Length; ++i)
                {
                    RockPathPart part = RockPathPart.Parse(parts[i]);
                    current.next = part;
                    current = part;

                    if (minX > current.posX)
                    {
                        minX = current.posX;
                    }

                    if (maxX < current.posX)
                    {
                        maxX = current.posX;
                    }

                    if (maxY < current.posY)
                    {
                        maxY = current.posY;
                    }
                }
            }

            /* FIXME: don't use "infinity", instead add additional sand based on sand on border y pos */
            minX = 0;
            maxX = 1024;

            char[][] grid = new char[maxY + 3][];
            for (int i = 0; i < grid.Length; ++i)
            {
                grid[i] = new String(AIR, maxX - minX + 1).ToCharArray();
            }

            RockPathPart bottomLeft = new()
            {
                posX = minX,
                posY = maxY + 2
            };

            RockPathPart bottomRight = new()
            {
                posX = maxX,
                posY = maxY + 2
            };

            bottomLeft.next = bottomRight;
            paths.Add(bottomLeft);


            paths.ForEach(p => p.AddPath(grid, minX, maxX));

            /* simluate sand */
            int sandCount = 0;
            while (grid[0][500 - minX] != SAND)
            {
                bool inMotion = true;
                (int x, int y) = (500, 0);
                ++sandCount;
                while (inMotion)
                {

                    if (grid[y + 1][x - minX] == AIR)
                    {
                        y += 1;
                        continue;
                    }
                    else
                    {
                        /* path below is blocked */
                        if (x - minX - 1 >= 0 && grid[y + 1][x - minX - 1] == AIR) /* check diagonal left */
                        {
                            x -= 1;
                            y += 1;
                            continue;
                        }
                        else if (x < maxX && grid[y + 1][x - minX + 1] == AIR) /* check diagonal right */
                        {
                            x += 1;
                            y += 1;
                            continue;
                        }
                        else
                        {
                            grid[y][x - minX] = SAND;
                            inMotion = false;
                        }

                    }
                }
            }

            /* now just add a little bit of sand left and right */


#if DEBUG
            PrintGrid(grid);
            Console.WriteLine(sandCount);
#endif
        }
    }
}
