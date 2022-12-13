foreach (var instructions in I.Data)
{
    var source = I.Stack[instructions.From - 1];

    var destinationArray = new char[I.Stack[instructions.To - 1].Count + instructions.Amount];
    I.Stack[instructions.To - 1].ToArray().CopyTo(destinationArray, 0);

    Array.Copy(
        source.ToArray(),
        source.Count - instructions.Amount,
        destinationArray,
        I.Stack[instructions.To - 1].Count,
        instructions.Amount);

    I.Stack[instructions.To - 1] = destinationArray.Where(x => x != '\0').ToList();

    I.Stack[instructions.From - 1].RemoveRange(source.Count - instructions.Amount, instructions.Amount);
}

Console.WriteLine(string.Join(string.Empty, I.Stack.Select(x => x.Last())));
