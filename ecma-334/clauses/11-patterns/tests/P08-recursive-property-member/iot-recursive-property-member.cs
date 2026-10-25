/*
Rules: P08-recursive-property-member
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: reject
Mutate: Missing: 17
Into: Key: 17
*/
class Item { public int Key { get { return 17; } } }
class Program
{
    static int Main() { return new Item() is { Missing: 17 } ? 0 : 1; }
}
