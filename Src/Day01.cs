using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Src
{
    public class Day01 : IAoC
    {
        public static void Part1()
        {
            var lines = File.ReadAllLines("Res/Day01.txt");

            int calories = 0;
            int maxCalories = 0;

            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    if (calories > maxCalories)
                    {
                        maxCalories = calories;
                    }
                    calories = 0;
                }
                else
                {
                    calories += int.Parse(line);
                }
            }

#if DEBUG
            Console.WriteLine(calories > maxCalories ? calories : maxCalories);
#endif
        }

        public static void Part2()
        {
            var lines = File.ReadAllLines("Res/Day01.txt");

            int calories = 0;
            List<int> calorieSum = new();

            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    calorieSum.Add(calories);
                    calories = 0;
                }
                else
                {
                    calories += int.Parse(line);
                }
            }
            calorieSum.Add(calories);
            calorieSum.Sort();

#if DEBUG
            Console.WriteLine(calorieSum[^1] + calorieSum[^2] + calorieSum[^3]);
#endif
        }
    }
}
