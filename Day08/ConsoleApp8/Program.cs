var inputDataRef = Input.Data;

int length = Convert.ToInt32(Math.Sqrt(inputDataRef.Length));

int[,] result = new int[length, length];

for (int i = 1; i < length - 1; i++)
{
    for (int j = 1; j < length - 1; j++)
    {
        int examinated = inputDataRef[i, j];

        int a = 0;
        int b = 0;
        int c = 0;
        int d = 0;

        // 1
        for (int k = i - 1; k >= 0; k--)
        {
            a++;
            int tester = inputDataRef[k, j];
            if (tester >= examinated)
            {
                break;
            }
        }

        // 2
        for (int k = i + 1; k <= length - 1; k++)
        {
            b++;
            int tester = inputDataRef[k, j];
            if (tester >= examinated)
            {
                break;
            }
        }

        // 3
        for (int k = j - 1; k >= 0; k--)
        {
            c++;
            int tester = inputDataRef[i, k];
            if (tester >= examinated)
            {
                break;
            }
        }

        // 4
        for (int k = j + 1; k <= length - 1; k++)
        {
            d++;
            int tester = inputDataRef[i, k];
            if (tester >= examinated)
            {
                break;
            }
        }

        result[i, j] = a * b * c * d;
    }
}

int highest = 0;

for (int i = 0; i < length; i++)
{
    for (int j = 0; j < length; j++)
    {
        if (highest < result[i, j])
        {
            highest = result[i, j];
        }
    }
}

Console.WriteLine(highest);
