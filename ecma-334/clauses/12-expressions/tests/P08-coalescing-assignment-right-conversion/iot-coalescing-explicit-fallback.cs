/*
Rules: P08-coalescing-assignment-right-conversion
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: reject
Mutate: slot ??= number;
Into: slot ??= (byte)number;
*/
class Program
{
    static void Main()
    {
        int number = 107;
        byte? slot = null;
        slot ??= number;
    }
}
