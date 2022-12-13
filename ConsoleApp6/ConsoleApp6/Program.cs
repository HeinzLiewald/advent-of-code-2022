using System.Collections.Immutable;

const short number = 14;

var splitted = Input.Data.ToImmutableArray();

for (int i = 0; i < splitted.Length; i++)
{
    List<char> check = new();

    for (int j = 0; j < number; j++)
    {
        check.Add(splitted[j + i]);
    }

    if (check.Distinct().Count() == number)
    {
        Console.WriteLine(i + number);
        return;
    }
}