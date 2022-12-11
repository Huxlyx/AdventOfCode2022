namespace AdventOfCode2022.Src
{
    public class Day11 : IAoC
    {
        private const string INPUT = "Res/Day11.txt";

        class Monkey
        {
            readonly List<int> Items;
            readonly Func<int, int> Operation;
            readonly Func<int, bool> Test;

            public Monkey trueReceiver;
            public Monkey falseReceiver;

            public int ItemsInspectedTotal { get; private set; }

            public Monkey(Func<int, int> operation, Func<int, bool> test, params int[] items)
            {
                Items = items.ToList();
                Operation = operation;
                Test = test;
            }

            public void DoTurn()
            {
                ItemsInspectedTotal += Items.Count;
                foreach (var item in Items)
                {
                    int newVal = Operation(item);
                    newVal /= 3;
                    if (Test(newVal))
                    {
                        trueReceiver.Items.Add(newVal);
                    }
                    else
                    {
                        falseReceiver.Items.Add(newVal);
                    }
                }
                Items.Clear();
            }
        }

        public static void Part1()
        {
            var lines = File.ReadAllLines(INPUT);
            List<Monkey> monkeys = new((lines.Length + 1) / 7);

            for (int i = 0; i < lines.Length; i += 7)
            {
                int[] items = lines[i + 1][(lines[i + 1].IndexOf(':') + 1)..].Split(',').ToArray().Select(x => int.Parse(x)).ToArray();
                string opLine = lines[i + 2];
                Func<int, int> operation;
                if (opLine.Contains('*'))
                {
                    if (opLine.IndexOf("old") != opLine.LastIndexOf("old")) /* old twice */
                    {
                        operation = x => x * x;
                    }
                    else
                    {
                        int mul = int.Parse(opLine[(opLine.IndexOf('*') + 1)..]);
                        operation = x => x * mul;
                    }
                }
                else
                {
                    int add = int.Parse(opLine[(opLine.IndexOf('+') + 1)..]);
                    operation = x => x + add;
                }

                string testLine = lines[i + 3];
                int mod = int.Parse(testLine[(testLine.IndexOf("by") + 3)..]);
                bool test(int x) => x % mod == 0;

                monkeys.Add(new Monkey(operation, test, items));
            }

            /* set references */
            int monkeyIndex = 0;
            for (int i = 0; i < lines.Length; i += 7)
            {
                int monkeyTrue = int.Parse(lines[i + 4][(lines[i + 4].IndexOf("monkey") + 7)..]);
                int monkeyFalse = int.Parse(lines[i + 5][(lines[i + 5].IndexOf("monkey") + 7)..]);
                monkeys[monkeyIndex].trueReceiver = monkeys[monkeyTrue];
                monkeys[monkeyIndex++].falseReceiver = monkeys[monkeyFalse];
            }

            for (int turns = 0; turns < 20; ++turns)
            {
                for (int i = 0; i < monkeys.Count; ++i)
                {
                    monkeys[i].DoTurn();
                    Console.WriteLine($"monkey{i}: {monkeys[i].ItemsInspectedTotal}");
                }
            }

            List<int> inspections = new();
            foreach (Monkey monkey in monkeys)
            {
                inspections.Add(monkey.ItemsInspectedTotal);
            }

            inspections.Sort();


#if DEBUG
            Console.WriteLine(inspections[^1] * inspections[^2]);
#endif
        }

        public static void Part2()
        {
            var lines = File.ReadAllLines(INPUT);



#if DEBUG
                Console.Write(" ");
#endif
            
        }
    }
}
