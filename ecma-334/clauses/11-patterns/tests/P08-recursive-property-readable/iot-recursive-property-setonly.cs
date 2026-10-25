/*
Rules: P08-recursive-property-readable
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: reject
Mutate: public int Key { set { } }
Into: public int Key { get { return 17; } set { } }
*/
class Item { public int Key { set { } } }
class Program
{
    static int Main() { return new Item() is { Key: 17 } ? 0 : 1; }
}
