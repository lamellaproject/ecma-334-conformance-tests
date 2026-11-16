/*
Rules: P08-recursive-property-readable
Authority: csc 5.12.0-1.26529.118 (C# 8.0)
Version: 8.0
Expected: reject
Mutate: private int Key { get { return 17; } }
Into: public int Key { get { return 17; } }
*/
class Item { private int Key { get { return 17; } } }
class Program
{
    static int Main() { return new Item() is { Key: 17 } ? 0 : 1; }
}
