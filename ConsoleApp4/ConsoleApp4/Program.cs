var result = Input
    .Data
    .Select(x => (
                    Enumerable.Range(x.FirstElf.start, x.FirstElf.end - x.FirstElf.start + 1),
                    Enumerable.Range(x.SecondElf.start, x.SecondElf.end - x.SecondElf.start + 1)
                 ))
    .Count(x => x.Item1.Any(y => x.Item2.Contains(y)));

Console.WriteLine(result);