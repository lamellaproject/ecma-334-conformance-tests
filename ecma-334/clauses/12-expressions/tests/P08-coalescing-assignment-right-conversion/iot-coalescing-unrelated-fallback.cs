/*
Rules: P08-coalescing-assignment-right-conversion
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: reject
Mutate: new Unrelated()
Into: new Anchor()
*/
class Anchor { }
class Unrelated { }
class Program
{
    static void Main()
    {
        Anchor slot = null;
        slot ??= new Unrelated();
    }
}
