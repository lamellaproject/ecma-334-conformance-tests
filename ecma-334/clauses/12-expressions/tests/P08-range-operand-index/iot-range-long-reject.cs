/*
Rules: P08-range-operand-index
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: reject
Mutate: long offset = 2;
Into: int offset = 2;
Csc: CS0029
*/
using System;
class Test
{
    static void Main()
    {
        long offset = 2;
        Range value = offset..;
        Console.WriteLine(value.Start.Value);
    }
}
