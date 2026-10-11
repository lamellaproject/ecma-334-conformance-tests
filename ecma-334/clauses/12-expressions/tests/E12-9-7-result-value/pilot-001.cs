/*
Rules: E12-9-7-result-value
Authority: ECMA-334 7th ed 12.9.7
Version: 7.3
Expected: reject
Mutate: Consume(ref (int)source)
Into: Consume(ref source)
Csc: CS1510
*/
using System;
using static Bridge;

static class Bridge { public static void Consume(ref int n) { n++; } }
class Program
{
    static void Main()
    {
        int source=61; Consume(ref (int)source);
    }
}
