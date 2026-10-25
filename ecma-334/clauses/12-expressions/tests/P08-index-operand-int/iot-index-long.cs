/*
Rules: P08-index-operand-int
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
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
