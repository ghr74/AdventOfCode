using System.Text.RegularExpressions;

namespace day02;

internal partial class Task1
{
    // ReSharper disable once InconsistentNaming
    private readonly List<string> inputs;

    public Task1(List<string> inputs)
    {
        this.inputs = inputs;
    }

    private bool ColorCountPossible(string color, int count)
    {
        return (color, count) switch
        {
            ("blue", <= 14) => true,
            ("red", <= 12) => true,
            ("green", <= 13) => true,
            _ => false
        };
    }
    
    public string? Run()
    {
        var sum = 0;
        foreach (var game in inputs)
        {
            var gameId = MatchIdRegex().Match(game).Groups[1].Value;
            var possible = true;
            foreach (var pull in game.Split(";"))
            {
                foreach (var color in pull.Split(","))
                {
                    var match = NumberColorRegex().Match(color);
                    var number = int.Parse(match.Groups[1].Value);
                    var name = match.Groups[2].Value;

                    if (!ColorCountPossible(name, number))
                    {
                        possible = false;
                    }
                }
            }

            if (possible)
            {
                sum += int.Parse(gameId);
            }
        }

        return sum.ToString();
    }
    
    [GeneratedRegex(@"(\d+):")]
    private static partial Regex MatchIdRegex();

    [GeneratedRegex(@"(?:\s(\d+)\s(blue|red|green)*)+")]
    private static partial Regex NumberColorRegex();
}