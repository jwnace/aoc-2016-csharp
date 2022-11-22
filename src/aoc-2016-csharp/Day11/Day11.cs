using System.Diagnostics;
using aoc_2016_csharp.Extensions;

namespace aoc_2016_csharp.Day11;

public static class Day11
{
    // private static readonly string[] Input = File.ReadAllLines("Day11/day11.txt");
    private static readonly Dictionary<List<List<string>>, int> Nodes = new();
    private static readonly PriorityQueue<List<List<string>>, int> Queue = new();

    public static int Part1()
    {
        // generate the initial state
        var start = new List<List<string>>
        {
            // A = promethium, B = cobalt, C = curium, D = ruthenium, E = plutonium
            new() { "AG", "AM", }, // first floor
            new() { "BG", "CG", "DG", "EG", }, // second floor
            new() { "E", "BM", "CM", "DM", "EM", }, // third floor
            new(), // fourth floor
        };

        Queue.Enqueue(start, 0);
        Nodes[start] = 0;

        Dijkstra();

        // generate the desired state
        var end = new List<List<string>>
        {
            // A = promethium, B = cobalt, C = curium, D = ruthenium, E = plutonium
            new() { }, // first floor
            new() { }, // second floor
            new() { }, // third floor
            new() { "E", "AG", "AM", "BG", "BM", "CG", "CM", "DG", "DM", "EG", "EM" }, // fourth floor
        };

        return Nodes[end];
    }

    public static int Part2()
    {
        return 2;
    }

    private static void Dijkstra()
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        var minutes = 0;

        while (Queue.Count > 0)
        {
            if (stopwatch.Elapsed.Minutes > minutes)
            {
                Console.WriteLine($"{stopwatch.Elapsed} => nodes: {Nodes.Count}, min: {Nodes.Values.Min()}, avg: {Nodes.Values.Average()}, max: {Nodes.Values.Max()}");
                Console.WriteLine();
                minutes = stopwatch.Elapsed.Minutes;
            }

            // get a node from the queue
            var node = Queue.Dequeue();

            // get all the possible next states
            for (var i = 0; i < node.Count; i++)
            {
                var currentFloor = node[i];

                if (currentFloor.Any(x => x == "E"))
                {
                    // the elevator is on floor i
                    var parts = currentFloor.Where(x => x != "E")
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .Select(x => x)
                        .ToList();

                    var p1 = parts.GetCombinations(1);
                    var p2 = parts.GetCombinations(2);
                    var potentialLoads = p1.Concat(p2).ToList();

                    var n1 = i - 1;
                    var n2 = i + 1;

                    foreach (var load in potentialLoads)
                    {
                        if (n2 < node.Count)
                        {
                            // go to n2
                            var newState = new List<List<string>>(node.Select(x => new List<string>(x)));
                            newState[n2].AddRange(load);
                            newState[n2].Add("E");
                            newState[i].RemoveAll(x => load.Contains(x));
                            newState[i].Remove("E");
                            newState = newState.Select(x => x.OrderBy(y => y).ToList()).ToList();

                            if (newState[3].Count == 11)
                            {
                                throw new Exception($"FOUND THE ANSWER! IT IS: {Nodes[node] + 1}");
                            }

                            var q1 = newState.Any(x => x.Contains("AM") && !x.Contains("AG") && x.Any(y => y.Contains('G')));
                            var q2 = newState.Any(x => x.Contains("BM") && !x.Contains("BG") && x.Any(y => y.Contains('G')));
                            var q3 = newState.Any(x => x.Contains("CM") && !x.Contains("CG") && x.Any(y => y.Contains('G')));
                            var q4 = newState.Any(x => x.Contains("DM") && !x.Contains("DG") && x.Any(y => y.Contains('G')));
                            var q5 = newState.Any(x => x.Contains("EM") && !x.Contains("EG") && x.Any(y => y.Contains('G')));

                            if (q1 || q2 || q3 || q4 || q5)
                            {
                                continue;
                            }

                            var d = Nodes[node] + 1;

                            if (!Nodes.TryGetValue(newState, out var nd) || d < nd)
                            {
                                Nodes[newState] = d;
                                Queue.Enqueue(newState, d);
                            }
                        }

                        if (i != 1 || node[0].Count != 0)
                        {
                            if (i != 2 || node[0].Count != 0 || node[1].Count != 0)
                            {
                                if (n1 > 0)
                                {
                                    var newState = new List<List<string>>(node.Select(x => new List<string>(x)));
                                    newState[n1].AddRange(load);
                                    newState[n1].Add("E");
                                    newState[i].RemoveAll(x => load.Contains(x));
                                    newState[i].Remove("E");
                                    newState = newState.Select(x => x.OrderBy(y => y).ToList()).ToList();

                                    var q1 = newState.Any(x => x.Contains("AM") && !x.Contains("AG") && x.Any(y => y.Contains('G')));
                                    var q2 = newState.Any(x => x.Contains("BM") && !x.Contains("BG") && x.Any(y => y.Contains('G')));
                                    var q3 = newState.Any(x => x.Contains("CM") && !x.Contains("CG") && x.Any(y => y.Contains('G')));
                                    var q4 = newState.Any(x => x.Contains("DM") && !x.Contains("DG") && x.Any(y => y.Contains('G')));
                                    var q5 = newState.Any(x => x.Contains("EM") && !x.Contains("EG") && x.Any(y => y.Contains('G')));

                                    if (q1 || q2 || q3 || q4 || q5)
                                    {
                                        continue;
                                    }

                                    var d = Nodes[node] + 1;

                                    if (!Nodes.TryGetValue(newState, out var nd) || d < nd)
                                    {
                                        Nodes[newState] = d;
                                        Queue.Enqueue(newState, d);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
