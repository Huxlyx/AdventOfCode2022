using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2022.Src
{
    public class Day07
    {
        private const string INPUT = "Res/Day07.txt";

        public static void RunDay07_1()
        {
            var lines = File.ReadAllLines(INPUT);
            Directory root = new("/", null);
            BuildStructure(lines, root);

            const int THRESHOLD = 100_000;
            Console.WriteLine(root.DirsRecurse().Where(dir => dir.Size <= THRESHOLD).Select(dir => dir.Size).ToList().Sum()); /* sum of dirs <= 100_000 */
        }

        public static void RunDay07_2()
        {
            var lines = File.ReadAllLines(INPUT);
            Directory root = new("/", null);
            BuildStructure(lines, root);

            long freeSpace = 70_000_000 - root.Size;
            foreach (Directory dir in root.DirsRecurse().OrderBy(dir => dir.Size))
            {
                if (freeSpace + dir.Size >= 30_000_000)
                {
                    Console.WriteLine(dir.Size);
                    break;
                }
            }

            Console.WriteLine();
        }

        private static void BuildStructure(string[] lines, Directory root)
        {
            Directory currentDir = root;
            for (int i = 1 /* skip cd to root */; i < lines.Length; ++i)
            {
                string currentLine = lines[i];
                if (currentLine.StartsWith("$ cd"))
                {
                    string targetDir = currentLine.Split(' ')[2];
                    if (targetDir == "..")
                    {
                        currentDir = currentDir.Parent ?? currentDir;
                    }
                    else
                    {
                        currentDir = currentDir.Directories.First(currentDir => currentDir.Name == targetDir);
                    }
                }
                else if (currentLine.StartsWith("$ ls"))
                {
                    for (i++; i < lines.Length; ++i)
                    {
                        string currentInnerLine = lines[i];
                        if (currentInnerLine.StartsWith('$')) /* new command */
                        {
                            --i;
                            break;
                        }
                        else if (currentInnerLine.StartsWith("dir"))
                        {
                            currentDir.Directories.Add(new(currentInnerLine.Split(' ')[1], currentDir));
                        }
                        else
                        {
                            var splits = currentInnerLine.Split(' ');
                            currentDir.AddFile(new(splits[1], int.Parse(splits[0])));
                        }
                    }
                }
                else
                {
                    throw new InvalidOperationException("HALP!" + i);
                }
            }
        }

        class Directory
        {
            public Directory(string name, Directory? parent)
            {
                Name = name;
                Parent = parent;
            }

            public string Name { get; init; }
            public Directory? Parent { get; init; }
            public long Size { get; private set; }
            private List<DirFile> Files { get; } = new();
            public List<Directory> Directories { get; } = new();

            public void AddFile(DirFile file)
            {
                Files.Add(file);
                AddSize(file.Size);
            }

            private void AddSize(long size)
            {
                Size += size;
                Parent?.AddSize(size);
            }

            public IEnumerable<Directory> DirsRecurse()
            {
                yield return this;
                foreach (Directory dir in Directories)
                {
                    foreach (Directory inner in dir.DirsRecurse())
                    {
                        yield return inner;
                    }
                }
            }

            public override string ToString()
            {
                return $"{Name} (dir, size={Size})";
            }
        }

        struct DirFile
        {
            public DirFile(string name, int size)
            {
                Name = name;
                Size = size;
            }

            public string Name { get; init; }
            public int Size { get; init; }
        }
    }
}
