// See https://aka.ms/new-console-template for more information

using day02;

List<string> inputs = new();

void GetInput()
{
    string? line;
        
    while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
    {
        inputs.Add(line);
    }
}

GetInput();

// var result = new Task1(inputs).Run();
var result = new Task2(inputs).Run();

Console.WriteLine(result);
// Task2.Run();