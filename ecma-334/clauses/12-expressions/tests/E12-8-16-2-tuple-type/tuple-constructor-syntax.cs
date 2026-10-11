/*
Rules: E12-8-16-2-tuple-type
Authority: ECMA-334 7th ed 12.8.16.2
Version: 7.3
Expected: reject
Mutate: new (int, int)(4, 8)
Into: (4, 8)
Csc: CS8181
*/
using System;
class Program
{
    static void Main() { var pair = new (int, int)(4, 8); Console.WriteLine(pair.Item1 + pair.Item2); }
}
