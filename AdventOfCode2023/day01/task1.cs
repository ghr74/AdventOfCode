using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace day01;

internal partial class Task1
{
    // ReSharper disable once InconsistentNaming
    private readonly List<string> inputs = new();
    private void GetInput()
    {
        string? line;
        
        while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
        {
            inputs.Add(line);
        }
    }

    private string ConvertNameToDigit(string digit)
    {
        return digit switch
        {
            "zero" => "0",
            "one" => "1",
            "two" => "2",
            "three" => "3",
            "four" => "4",
            "five" => "5",
            "six" => "6",
            "seven" => "7",
            "eight" => "8",
            "nine" => "9",
            _ => "ERROR"
        };
    }
    
    public string? Run()
    {
        GetInput();

        var sum = 0;
        
        foreach (var input in inputs)
        {
            var firstDigit = FirstNumberRegex().Match(input).Groups[1].Value;
            if (firstDigit.Length > 1)
            {
                firstDigit = ConvertNameToDigit(firstDigit);
            }
            var secondDigit = LastNumberRegex().Match(input).Groups[1].Value;
            if (secondDigit.Length > 1)
            {
                secondDigit = ConvertNameToDigit(secondDigit);
            }
            
            var value = Int32.Parse(firstDigit + secondDigit);
            sum += value;
        }

        return sum.ToString();
    }
    
    [GeneratedRegex(@"(\d|zero|one|two|three|four|five|six|seven|eight|nine)")]
    private static partial Regex FirstNumberRegex();

    [GeneratedRegex(@".*(\d|zero|one|two|three|four|five|six|seven|eight|nine).*$")]
    private static partial Regex LastNumberRegex();
}