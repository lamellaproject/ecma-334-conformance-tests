/*
Rules: P08-coalescing-assignment-value-left
Authority: csc 5.12.0-1.26529.118 (C# 8.0)
Version: 8.0
Expected: reject
Mutate: int slot = 0;
Into: int? slot = 0;
*/
class Program
{
    static void Main()
    {
        int slot = 0;
        slot ??= 103;
    }
}
