var monkeys = Input.Data;
var numberOfMonkeys = monkeys.Length;

var commonTestDivisible = monkeys.Aggregate((ulong)1, (acc, curr) => acc * curr.TestDivisible);

for (var roundIndex = 0; roundIndex < 10_000; roundIndex++)
{
    for (var monkeyIndex = 0; monkeyIndex < numberOfMonkeys; monkeyIndex++)
    {
        var currentMonkey = monkeys[monkeyIndex];

        while (currentMonkey.Items.Any())
        {
            var currentItem = currentMonkey.Items.Dequeue();

            if (currentMonkey.OperationOperator == "+")
                currentItem = (currentItem + currentMonkey.OperationValue) % commonTestDivisible;
            else if (currentMonkey.OperationOperator == "*")
                currentItem = (currentItem * currentMonkey.OperationValue) % commonTestDivisible;
            else if (currentMonkey.OperationOperator == "power")
                currentItem = (currentItem * currentItem) % commonTestDivisible;
            else
                throw new Exception();

            currentMonkey.NumberOfInspections++;

            if (currentItem % currentMonkey.TestDivisible == 0)
                monkeys[currentMonkey.MonkeyIfTrue].Items.Enqueue(currentItem);
            else
                monkeys[currentMonkey.MonkeyIfFalse].Items.Enqueue(currentItem);
        }
    }
}

var answer = monkeys.OrderByDescending(x => x.NumberOfInspections).Take(2);

Console.WriteLine(answer.First().NumberOfInspections * answer.Last().NumberOfInspections);
