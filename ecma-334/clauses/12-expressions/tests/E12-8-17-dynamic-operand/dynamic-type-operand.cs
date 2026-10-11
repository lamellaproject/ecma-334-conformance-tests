/*
Rules: E12-8-17-dynamic-operand
Authority: ECMA-334 7th ed 12.8.17
Version: 7.3
Expected: reject
Mutate: typeof(dynamic)
Into: typeof(object)
Csc: CS1962
*/
using System;
class Program
{
    static void Main() { Type type = typeof(dynamic); Console.WriteLine(type != null); }
}
