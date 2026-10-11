/*
Rules: E12-8-20-literal-untyped
Authority: ECMA-334 7th ed 12.8.20
Version: 7.3
Expected: reject
Mutate: var value = default;
Into: var value = default(int);
Csc: CS8716
*/
using System;
class Program
{
    static void Main() { var value = default; Console.WriteLine(value); }
}
