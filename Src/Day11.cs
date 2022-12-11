using System.Numerics;

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
                int[] items = lines[i + 1][(lines[i + 1].IndexOf(':') + 1)..].Split(',').ToArray().Select(int.Parse).ToArray();
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

        class Monkey2
        {
            readonly List<long> Items;
            readonly Func<long, long> Operation;
            readonly long TestVal;

            public Monkey2 trueReceiver;
            public Monkey2 falseReceiver;

            public long commonFactor;

            public long ItemsInspectedTotal { get; private set; }

            public Monkey2(Func<long, long> operation, long testVal, params long[] items)
            {
                Items = items.ToList();
                Operation = operation;
                TestVal = testVal;
            }
            public void DoTurn()
            {
                ItemsInspectedTotal += Items.Count;
                foreach (var item in Items)
                {
                    long newVal = Operation(item);
                    newVal %= commonFactor;
                    if (newVal % TestVal == 0)
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

        public static void Part2()
        {
            var lines = File.ReadAllLines(INPUT);
            List<Monkey2> monkeys = new((lines.Length + 1) / 7);

            int commonFactor = 1;

            for (int i = 0; i < lines.Length; i += 7)
            {
                long[] items = lines[i + 1][(lines[i + 1].IndexOf(':') + 1)..].Split(',').ToArray().Select(long.Parse).ToArray();
                string opLine = lines[i + 2];
                Func<long, long> operation;
                if (opLine.Contains('*'))
                {
                    if (opLine.IndexOf("old") != opLine.LastIndexOf("old")) /* old twice */
                    {
                        operation = x => x * x;
                    }
                    else
                    {
                        long mul = long.Parse(opLine[(opLine.IndexOf('*') + 1)..]);
                        operation = x => x * mul;
                    }
                }
                else
                {
                    long add = long.Parse(opLine[(opLine.IndexOf('+') + 1)..]);
                    operation = x => x + add;
                }

                string testLine = lines[i + 3];
                int mod = int.Parse(testLine[(testLine.IndexOf("by") + 3)..]);
                commonFactor *= mod;

                monkeys.Add(new Monkey2(operation, mod, items));
            }

            /* set references */
            int monkeyIndex = 0;
            for (int i = 0; i < lines.Length; i += 7)
            {
                int monkeyTrue = int.Parse(lines[i + 4][(lines[i + 4].IndexOf("monkey") + 7)..]);
                int monkeyFalse = int.Parse(lines[i + 5][(lines[i + 5].IndexOf("monkey") + 7)..]);
                monkeys[monkeyIndex].commonFactor = commonFactor;
                monkeys[monkeyIndex].trueReceiver = monkeys[monkeyTrue];
                monkeys[monkeyIndex++].falseReceiver = monkeys[monkeyFalse];
            }

            for (int turns = 0; turns < 10_000; ++turns)
            {
                for (int i = 0; i < monkeys.Count; ++i)
                {
                    monkeys[i].DoTurn();
                }
            }

            List<long> inspections = new();
            foreach (Monkey2 monkey in monkeys)
            {
                inspections.Add(monkey.ItemsInspectedTotal);
            }

            inspections.Sort();

            BigInteger big1 = inspections[^1];
            BigInteger big2 = inspections[^2];

#if DEBUG
            Console.WriteLine(big1 * big2);
#endif
        }
    }
}
