using System.Text.RegularExpressions;

namespace day02;

internal partial class Task2 {
    // ReSharper disable once InconsistentNaming
    private readonly List<string> inputs;

    public Task2(List<string> inputs)
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
            var lred = 0;
            var lblue = 0;
            var lgreen = 0;
            foreach (var pull in game.Split(";"))
            {
                foreach (var color in pull.Split(","))
                {
                    var match = NumberColorRegex().Match(color);
                    var number = int.Parse(match.Groups[1].Value);
                    var name = match.Groups[2].Value;

                    switch (name)
                    {
                        case "blue" when number > lblue:
                            lblue = number;
                            break;
                        case "red" when number > lred:
                            lred = number;
                            break;
                        case "green" when number > lgreen:
                            lgreen = number;
                            break;
                    }
                }
            }

            sum += lred * lblue * lgreen;
        }

        return sum.ToString();
    }
    
    [GeneratedRegex(@"(\d+):")]
    private static partial Regex MatchIdRegex();

    [GeneratedRegex(@"(?:\s(\d+)\s(blue|red|green)*)+")]
    private static partial Regex NumberColorRegex();
}
