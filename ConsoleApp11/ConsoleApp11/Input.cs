public static class Input
{
    public static InstructionSet<ulong>[] Data = new InstructionSet<ulong>[]
    {
        new(new() { 66, 71, 94, }, "*", 5, 3, 7, 4),
        new(new() { 70, }, "+", 6, 17, 3, 0),
        new(new() { 62, 68, 56, 65, 94, 78, }, "+", 5, 2, 3, 1),
        new(new() { 89, 94, 94, 67, }, "+", 2, 19, 7, 0),
        new(new() { 71, 61, 73, 65, 98, 98, 63, }, "*", 7, 11, 5, 6),
        new(new() { 55, 62, 68, 61, 60, }, "+", 7, 5, 2, 1),
        new(new() { 93, 91, 69, 64, 72, 89, 50, 71, }, "+", 1, 13, 5, 2),
        new(new() { 76, 50, }, "power", 0, 7, 4, 6),
    };

    public static InstructionSet<ulong>[] TestData = new InstructionSet<ulong>[]
    {
        new(new() { 79, 98, }, "*", 19, 23, 2, 3),
        new(new() { 54, 65, 75, 74, }, "+", 6, 19, 2, 0),
        new(new() { 79, 60, 97, }, "power", 0, 13, 1, 3),
        new(new() { 74, }, "+", 3, 17, 0, 1),
    };
}

public class InstructionSet<T>
{
    public InstructionSet(
        List<T> items,
        string operationOperator,
        T operationValue,
        T testDivisible,
        int monkeyIfTrue,
        int monkeyIfFalse)
    {
        Items = new();
        foreach (var i in items)
        {
            Items.Enqueue(i);
        }
        OperationOperator = operationOperator;
        OperationValue = operationValue;
        TestDivisible = testDivisible;
        MonkeyIfTrue = monkeyIfTrue;
        MonkeyIfFalse = monkeyIfFalse;
        NumberOfInspections = 0;
    }

    public Queue<T> Items { get; set; }
    public string OperationOperator { get; set; }
    public T OperationValue { get; set; }
    public T TestDivisible { get; set; }
    public int MonkeyIfTrue { get; set; }
    public int MonkeyIfFalse { get; set; }
    public T NumberOfInspections { get; set; }
}
