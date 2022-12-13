var total = 0;

foreach (var record in Input.Data)
{
    if (record.FirstMove == "A")
    {
        if (record.SecondMove == "X")
        {
            total += 3;
        }
        else if(record.SecondMove == "Y")
        {
            total += 1 + 3;
        }
        else // record.SecondMove == "Z"
        {
            total += 2 + 6;
        }
    }
    else if (record.FirstMove == "B")
    {
        if (record.SecondMove == "X")
        {
            total += 1;
        }
        else if (record.SecondMove == "Y")
        {
            total += 2 + 3;
        }
        else // record.SecondMove == "Z"
        {
            total += 3 + 6;
        }
    }
    else // record.FirstMove == "C"
    {
        if (record.SecondMove == "X")
        {
            total += 2;
        }
        else if (record.SecondMove == "Y")
        {
            total += 3 + 3;
        }
        else // record.SecondMove == "Z"
        {
            total += 1 + 6;
        }
    }
}

Console.WriteLine(total);