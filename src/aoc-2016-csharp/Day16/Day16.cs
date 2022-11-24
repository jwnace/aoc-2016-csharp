namespace aoc_2016_csharp.Day16;

public static class Day16
{
    private static readonly string Input = File.ReadAllText("Day16/day16.txt");

    public static string Part1()
    {
        var diskSize = 272;
        var data = ExpandData(Input, diskSize);

        return GetChecksum(data);
    }

    public static string Part2()
    {
        var diskSize = 35651584;
        var data = ExpandData(Input, diskSize);
        var chunkSize = GetChunkSize(diskSize);

        return GetChecksum(data, chunkSize);
    }

    private static string ExpandData(string input, int targetSize)
    {
        var data = input;

        while (data.Length < targetSize)
        {
            data = ExpandData(data);
        }

        return data[..targetSize];
    }

    public static string ExpandData(string input)
    {
        var a = input;
        var b = new string(input.Reverse().Select(x => x == '0' ? '1' : '0').ToArray());

        return $"{a}0{b}";
    }

    private static int GetChunkSize(int diskSize)
    {
        var chunkSize = 2;

        while (diskSize % (chunkSize * 2) == 0)
        {
            chunkSize *= 2;
        }

        return chunkSize;
    }

    public static string GetChecksum(string input)
    {
        var checksum = input;

        while (checksum.Length % 2 == 0)
        {
            checksum = new string(
                checksum.Chunk(2).Aggregate(
                    Array.Empty<char>(),
                    (result, pair) => result.Concat(new[] { pair[0] == pair[1] ? '1' : '0' }).ToArray()));
        }

        return checksum;
    }

    private static string GetChecksum(string input, int chunkSize) => new(
        input.Chunk(chunkSize).Aggregate(
            Array.Empty<char>(),
            (result, chunk) => result.Concat(new[] { chunk.Count(x => x == '1') % 2 == 0 ? '1' : '0' }).ToArray()));
}
