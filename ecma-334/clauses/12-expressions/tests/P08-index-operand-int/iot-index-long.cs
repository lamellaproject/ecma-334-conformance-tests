/*
Rules: P08-index-operand-int
Authority: csc 5.12.0-1.26529.118 (C# 8.0)
Version: 8.0
Expected: reject
Mutate: ^distance
Into: ^(int)distance
*/
using System;
class Program
{
    static void Main()
    {
        long distance = 3;
        Index result = ^distance;
        Console.WriteLine(result.Value);
    }
}
