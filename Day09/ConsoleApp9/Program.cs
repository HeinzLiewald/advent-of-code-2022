List<Position> visited = new();

Position[] tailPosition = new[]
{
    new Position() { X = 0, Y = 0 },
    new Position() { X = 0, Y = 0 },
    new Position() { X = 0, Y = 0 },
    new Position() { X = 0, Y = 0 },
    new Position() { X = 0, Y = 0 },
    new Position() { X = 0, Y = 0 },
    new Position() { X = 0, Y = 0 },
    new Position() { X = 0, Y = 0 },
    new Position() { X = 0, Y = 0 },
};
Position headPosition = new(){ X = 0, Y = 0 };

foreach (var newPosition in Input.Data)
{
    for (int x = 0; x < newPosition.Amount; x++)
    {
        if (newPosition.Direction == 'U')
        {
            headPosition.Y++;
        }
        else if (newPosition.Direction == 'D')
        {
            headPosition.Y--;
        }
        else if (newPosition.Direction == 'L')
        {
            headPosition.X--;
        }
        else if (newPosition.Direction == 'R')
        {
            headPosition.X++;
        }

        for (int i = 0; i < 9; i++)
        {
            Position following;
            if (i == 0)
            {
                following = headPosition;
            }
            else
            {
                following = tailPosition[i - 1];
            }

            //if (i == 8)
            //{
            //    Console.WriteLine($"{tailPosition[i].X} {tailPosition[i].Y}");
            //}

            if (IsDiagonallyAdjacent(tailPosition[i], following))
            {
                continue;
            }
            else if (IsHorizontalOrVertical(tailPosition[i], following))
            {
                if (tailPosition[i].Y < following.Y)
                {
                    tailPosition[i].Y++;
                }
                else if (tailPosition[i].Y > following.Y)
                {
                    tailPosition[i].Y--;
                }
                else if (tailPosition[i].X > following.X)
                {
                    tailPosition[i].X--;
                }
                else if (tailPosition[i].X < following.X)
                {
                    tailPosition[i].X++;
                }
            }
            else
            {
                var movements = GetExtraMoveNeeded(tailPosition[i], following);

                foreach (var extraMoveNeeded in movements)
                {
                    if (extraMoveNeeded == 'U')
                    {
                        tailPosition[i].Y++;
                    }
                    else if (extraMoveNeeded == 'D')
                    {
                        tailPosition[i].Y--;
                    }
                    else if (extraMoveNeeded == 'L')
                    {
                        tailPosition[i].X--;
                    }
                    else if (extraMoveNeeded == 'R')
                    {
                        tailPosition[i].X++;
                    }
                }
            }
        }

        visited.Add(new() { X = tailPosition[8].X, Y = tailPosition[8].Y });
    }
}

var answer = visited.Select(v => (v.X, v.Y)).Distinct();

Console.WriteLine(answer.Count());

List<char> GetExtraMoveNeeded(Position a, Position b)
{
    List<char> movements = new();

    if (a.X < b.X)
    {
        movements.Add('R');
    }
    else
    {
        movements.Add('L');
    }

    if (a.Y < b.Y)
    {
        movements.Add('U');
    }
    else
    {
        movements.Add('D');
    }

    return movements;
}

bool IsDiagonallyAdjacent(Position a, Position b)
{
    var dx = Math.Abs(a.X - b.X);
    var dy = Math.Abs(a.Y - b.Y);

    return dx <= 1 && dy <= 1;

    //return
    //    tailPosition.X <= headPosition.X + 1 &&
    //    tailPosition.X >= headPosition.X - 1 &&
    //    tailPosition.Y <= headPosition.Y + 1 &&
    //    tailPosition.Y >= headPosition.Y - 1;
}

bool IsHorizontalOrVertical(Position a, Position b)
{
    return
         a.X == b.X
        ||
         a.Y == b.Y;
}

class Position
{
    public int X { get; set; }
    public int Y { get; set; }
}