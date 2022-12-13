int cycle = 1;
var acc = 1;

List<(string Instruction, int Amount, int Iteration, int Acc)> result = new();

foreach (string? record in Input.Data)
{
    var recordSplitted = record.Split(" ");

    string instruction = recordSplitted[0];

    if (instruction == "noop")
    {
        result.Add((instruction, 0, cycle, acc));

        cycle++;
    }
    else
    {
        int amount = int.Parse(recordSplitted[1]);

        result.Add((instruction, amount, cycle, acc));

        cycle++;

        result.Add(("----", 0, cycle, acc));

        cycle++;

        acc += amount;
    }
}

List<(int Column, int Row, int From, int To)> computed =
    result.Select(x =>
        ((x.Iteration - 1) % 40,
         (x.Iteration - 1) / 40,
         x.Acc - 1,
         x.Acc + 1)).ToList();

List<(bool IsOn, int X, int Y)>? answer =
    computed.Select(x =>
        (x.Column >= x.From && x.Column <= x.To,
         x.Column,
         x.Row)).ToList();

for (int y = 0; y < 6; y++)
{
    var row = answer.Where(r => r.Y == y).ToList();

    foreach (var r in row)
        Console.Write(r.IsOn ? "X" : " ");

    Console.WriteLine();
}
