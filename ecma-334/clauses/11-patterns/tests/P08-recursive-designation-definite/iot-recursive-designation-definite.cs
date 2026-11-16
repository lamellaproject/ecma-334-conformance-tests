/*
Rules: P08-recursive-designation-definite
Authority: csc 5.12.0-1.26529.118 (C# 8.0)
Version: 8.0
Expected: reject
Mutate: if (!(item is { Code: 7 } selected))
Into: if (item is { Code: 7 } selected)
*/
class Item { public int Code = 7; }
class Program
{
    static int Main()
    {
        Item item = new Item();
        if (!(item is { Code: 7 } selected)) return selected.Code;
        return 0;
    }
}
