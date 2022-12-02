using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Src
{
    public class Day01
    {
        public static void RunDay01_1()
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

            Console.WriteLine(calories > maxCalories ? calories : maxCalories);
        }

        public static void RunDay01_2()
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

            Console.WriteLine(calorieSum[^1] + calorieSum[^2] + calorieSum[^3]);
        }
    }
}
