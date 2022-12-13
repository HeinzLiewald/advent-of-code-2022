int total = 0;

foreach (var record in Input.Data.Chunk(3))
{
    var commonLetter = record[0].FirstOrDefault(x => record[1].Contains(x) && record[2].Contains(x));

    if (commonLetter >= 'a')
        total += commonLetter - 96;
    else
        total += commonLetter - 38;
}

Console.WriteLine(total);