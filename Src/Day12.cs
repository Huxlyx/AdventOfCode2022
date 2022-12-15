using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Numerics;

namespace AdventOfCode2022.Src
{
    public class Day12 : IAoC
    {
        private const string INPUT = "Res/Day12.txt";


  
        public static void Part1()
        {
            var lines = File.ReadAllLines(INPUT);
            var elevationMap = lines.Select(line => Array.ConvertAll(line.ToCharArray(), ch => ch == 'E' ? 27 : ch == 'S' ? 0 : ch - 'a' + 1)).ToArray();

            bool[][] visited = new bool[elevationMap.Length][];
            for (int i = 0; i < elevationMap.Length; i++) 
            {
                visited[i] = new bool[elevationMap[0].Length];
            }

            int startX = 0;
            int startY = 0;

            for (int y = 0; y < elevationMap.Length; y++)
            {
                for (int x = 0; x < elevationMap[y].Length; x++)
                {
                    if (elevationMap[y][x] == 0)
                    {
                        startX = x;
                        startY = y;
                        break;
                    }
                }
            }


            Queue<(int x, int y, int level)> queue = new();
            queue.Enqueue((startX, startY, 0));
            //visited[startY][startX] = true;

            while (queue.Count > 0) 
            { 
                var pos = queue.Dequeue();
                int elevation = elevationMap[pos.y][pos.x];
                if (visited[pos.y][pos.x])
                {
                    continue;
                }
                visited[pos.y][pos.x] = true;

                if (pos.x == 79 && pos.y == 11)
                {
                    Console.WriteLine("HALP");
                }

                Console.WriteLine($"X:{pos.x} Y:{pos.y} steps:{pos.level} elevation:{elevation} queueSize:{queue.Count}");

                if (elevation == 27)
                {
                    Console.WriteLine(pos.level);
                    break;
                }

                /* try up */
                if (pos.y - 1 >= 0)
                {
                    int eleDiff = elevation - elevationMap[pos.y - 1][pos.x];
                    if (eleDiff >= -1 && eleDiff <= 1 && ! visited[pos.y - 1][pos.x])
                    {
                        queue.Enqueue((pos.x, pos.y - 1, pos.level + 1));
                        //visited[pos.y - 1][pos.x] = true;
                    }
                }

                /* try down */
                if (pos.y + 1 < elevationMap.Length)
                {
                    int eleDiff = elevation - elevationMap[pos.y + 1][pos.x];
                    if (eleDiff >= -1 && eleDiff <= 1 && ! visited[pos.y + 1][pos.x])
                    {
                        queue.Enqueue((pos.x, pos.y + 1, pos.level + 1));
                        //visited[pos.y + 1][pos.x] = true;
                    }
                }

                /* try left */
                if (pos.x - 1 >= 0)
                {
                    int eleDiff = elevation - elevationMap[pos.y][pos.x - 1];
                    if (eleDiff >= -1 && eleDiff <= 1 && ! visited[pos.y][pos.x - 1])
                    {
                        queue.Enqueue((pos.x - 1, pos.y, pos.level + 1));
                        //visited[pos.y][pos.x - 1] = true;
                    }
                }

                /* try right */
                if (pos.x + 1 < elevationMap[0].Length)
                {
                    int eleDiff = elevation - elevationMap[pos.y][pos.x + 1];
                    if (eleDiff >= -1 && eleDiff <= 1 && ! visited[pos.y][pos.x + 1])
                    {
                        queue.Enqueue((pos.x + 1, pos.y, pos.level + 1));
                        //visited[pos.y][pos.x + 1] = true;
                    }
                }
            }


#if DEBUG
            //Console.WriteLine(inspections[^1] * inspections[^2]);
#endif
        }


        public static void Part2()
        {
            var lines = File.ReadAllLines(INPUT);
         

#if DEBUG
            //Console.WriteLine(big1 * big2);
#endif
        }
    }
}
