using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace AdventOfCode2022.Src
{
    public class Day15 : IAoC
    {
        private const string INPUT = "Res/Day15.txt";

        struct Beacon
        {
            public int PosX { get; init; }
            public int PosY { get; init; }
        }

        struct Sensor
        {
            public int PosX { get; init; }
            public int PosY { get; init; }
            public Beacon Closest { get; init; }
        }

        public static void Part1()
        {
            var lines = File.ReadAllLines(INPUT);





#if DEBUG
            //PrintGrid(grid);
            //Console.WriteLine(sandCount);
#endif
        }


        public static void Part2()
        {
            var lines = File.ReadAllLines(INPUT);



#if DEBUG
            //PrintGrid(grid);
            //Console.WriteLine(sandCount);
#endif
        }
    }
}
