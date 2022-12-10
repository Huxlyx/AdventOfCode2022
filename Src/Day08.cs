
namespace AdventOfCode2022.Src
{
    public class Day08 : IAoC
    {
        private const string INPUT = "Res/Day08.txt";

        public static void Part1()
        {
            var lines = File.ReadAllLines(INPUT);
            var treeMap = lines.Select(line => Array.ConvertAll(line.ToCharArray(), ch => ch - '0')).ToArray();

            int visible = 0;
            /* horizontal scan */
            for (int y = 0; y < treeMap.Length; y++)
            {
                int highest = -1;
                for (int x = 0; x < treeMap.Length; ++x)
                {
                    MaybeMark(treeMap, x, y, ref highest, ref visible);
                }

                highest = -1;
                for (int x = treeMap.Length - 1; x >= 0; --x)
                {
                    MaybeMark(treeMap, x, y, ref highest, ref visible);
                }
            }

            /* vertical scan */
            for (int x = 0; x < treeMap.Length; x++)
            {
                int highest = -1;
                for (int y = 0; y < treeMap.Length; ++y)
                {
                    MaybeMark(treeMap, x, y, ref highest, ref visible);
                }

                highest = -1;
                for (int y = treeMap.Length - 1; y >= 0; --y)
                {
                    MaybeMark(treeMap, x, y, ref highest, ref visible);
                }
            }

#if DEBUG
            Console.WriteLine(visible);
#endif
        }

        private static void MaybeMark(int[][] map, int x, int y, ref int highest, ref int visible)
        {
            if (Math.Abs(map[y][x]) > highest)
            {
                highest = Math.Abs(map[y][x]);

                int val = map[y][x];
                if (val > 0)
                {
                    map[y][x] = -val; /* mark visible trees with negative sign */
                    ++visible;
                }
                else if (val == 0)
                {
                    map[y][x] = -1; /* special handling for 0 since integers cannot be -0 :( 🙈 */
                    ++visible;
                }
            }
        }

        public static void Part2()
        {
            var lines = File.ReadAllLines(INPUT);
            var treeMap = lines.Select(line => Array.ConvertAll(line.ToCharArray(), ch => ch - '0')).ToArray();

            int maxScenicScore = 0;
            for (int y = 1; y < treeMap.Length - 1; y++)
            {
                int scenicScore = 1;
                for (int x = 1; x < treeMap.Length - 1; ++x)
                {
                    int currentHeight = treeMap[y][x];
                    int treesLeft = 1;
                    for (int goLeft = x - 1; goLeft > 0; --goLeft)
                    {
                        if (treeMap[y][goLeft] >= currentHeight)
                        {
                            break;
                        }
                        ++treesLeft;
                    }
                    int treesRight = 1;
                    for (int goRight = x + 1; goRight < treeMap.Length - 1; ++goRight)
                    {
                        if (treeMap[y][goRight] >= currentHeight)
                        {
                            break;
                        }
                        ++treesRight;
                    }
                    int treesUp = 1;
                    for (int goUp = y - 1; goUp > 0; --goUp)
                    {
                        if (treeMap[goUp][x] >= currentHeight)
                        {
                            break;
                        }
                        ++treesUp;
                    }
                    int treesDown = 1;
                    for (int goDown = y + 1; goDown < treeMap.Length - 1; ++goDown)
                    {
                        if (treeMap[goDown][x] >= currentHeight)
                        {
                            break;
                        }
                        ++treesDown;
                    }

                    scenicScore = treesLeft * treesRight * treesUp * treesDown;

                    if (scenicScore > maxScenicScore)
                    {
                        maxScenicScore = scenicScore;
                    }
                }
            }

#if DEBUG
            Console.WriteLine(maxScenicScore);
#endif
        }
    }
}
