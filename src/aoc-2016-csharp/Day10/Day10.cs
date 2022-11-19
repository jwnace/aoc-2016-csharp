namespace aoc_2016_csharp.Day10;

public static class Day10
{
    private static readonly string[] Input = File.ReadAllLines("Day10/day10.txt");

    public static string Part1()
    {
        var bots = LoadBots();

        while (bots.Any(x => x.Chips.Count == 2))
        {
            var bot = bots.First(x => x.Chips.Count == 2);
            var comparison = bot.Run();

            if (comparison.Low == 17 && comparison.High == 61)
            {
                return bot.Name;
            }
        }

        return "not found";
    }

    public static int Part2()
    {
        var bots = LoadBots();

        while (bots.Any(x => x.Chips.Count == 2))
        {
            bots.First(x => x.Chips.Count == 2).Run();

            var output0 = GetBot(bots, "output 0");
            var output1 = GetBot(bots, "output 1");
            var output2 = GetBot(bots, "output 2");

            if (output0.Chips.Count == 1 && output1.Chips.Count == 1 && output2.Chips.Count == 1)
            {
                return output0.Chips.First() * output1.Chips.First() * output2.Chips.First();
            }
        }

        return 0;
    }

    private static List<Bot> LoadBots()
    {
        var bots = new List<Bot>();

        foreach (var line in Input)
        {
            var temp = line.Split(' ');

            if (temp[0] == "value")
            {
                var bot = GetBot(bots, $"bot {temp[^1]}");
                bot.Chips.Add(int.Parse(temp[1]));
            }
            else
            {
                var bot = GetBot(bots, $"{temp[0]} {temp[1]}");
                var lowBot = GetBot(bots, $"{temp[5]} {temp[6]}");
                var highBot = GetBot(bots, $"{temp[10]} {temp[11]}");
                bot.LowOutput = lowBot;
                bot.HighOutput = highBot;
            }
        }

        return bots;
    }

    private static Bot GetBot(List<Bot> bots, string botName)
    {
        var bot = bots.FirstOrDefault(b => b.Name == botName);

        if (bot is null)
        {
            bot = new Bot(botName);
            bots.Add(bot);
        }

        return bot;
    }

    private class Bot
    {
        public string Name { get; }
        public List<int> Chips { get; } = new();
        public Bot? LowOutput { get; set; }
        public Bot? HighOutput { get; set; }

        public Bot(string name)
        {
            Name = name;
        }

        public (int Low, int High) Run()
        {
            if (Chips.Count != 2)
            {
                throw new InvalidOperationException("this bot does not have two chips");
            }

            if (LowOutput is null || HighOutput is null)
            {
                throw new InvalidOperationException("this bot has not been fully configured");
            }

            var (low, high) = (Chips.Min(), Chips.Max());

            LowOutput.Chips.Add(low);
            HighOutput.Chips.Add(high);
            Chips.Clear();

            return (low, high);
        }
    }
}
