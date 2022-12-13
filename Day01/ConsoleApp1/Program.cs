List<int> totals = new();

int localMax = 0;

foreach (var record in Input.Data)
{
    if (string.IsNullOrEmpty(record))
    {
        totals.Add(localMax);
        localMax = 0;
    }
    else
    {
        localMax += int.Parse(record);
    }
}

Console.WriteLine(totals.OrderByDescending(x => x).Take(3).Sum());