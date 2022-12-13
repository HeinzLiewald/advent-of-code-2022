Node? dummy = null;

Node root = new(ref dummy!, "/", 0);
Node curr = root;

foreach (var record in Input.Data)
{
    if (record == "$ ls")
        continue;

    if (record.StartsWith("$ cd"))
    {
        if (record == "$ cd ..")
            curr = curr.Parent!;
        else
        {
            var dir = record.Replace("$ cd ", string.Empty);

            var child = curr.Children.SingleOrDefault(x => x.Dir == dir);

            if (child is null)
            {
                child = new(ref curr!, dir, 0);
                curr.Children.Add(child);
            }
            curr = child;
        }

        continue;
    }

    if (record.StartsWith("dir"))
    {
        continue;
    }
    else
    {
        var size = int.Parse(record.Split(" ")[0]);
        curr.Size += size;
    }
}

FillTotalSize(root);

const int total = 70000000;
int bestAnswer = 30000000;
int limit = 30000000 - total + root.TotalSize;

FindBestAnswer(root);

Console.WriteLine(bestAnswer);

void FindBestAnswer(Node node)
{
    if(node.TotalSize > limit && node.TotalSize < bestAnswer)
    {
        bestAnswer = node.TotalSize;
    }

    foreach (var n in node.Children)
    {
        FindBestAnswer(n);
    }
}

void FillTotalSize(Node node)
{
    node.TotalSize = node.Size + ChildrenSize(node);

    foreach (var n in node.Children)
    {
        FillTotalSize(n);
    }
}

int ChildrenSize(Node node)
{
    int total = 0;

    foreach (var n in node.Children)
    {
        total += n.Size + ChildrenSize(n);
    }

    return total;
}

class Node
{
    public Node(ref Node? parent, string dir, int size)
    {
        Parent = parent;
        Dir = dir;
        Size = size;
        Children = new();
    }

    public Node? Parent { get; set; }
    public string Dir { get; set; }
    public int Size { get; set; }
    public int TotalSize { get; set; }
    public List<Node> Children { get; set; }
}
