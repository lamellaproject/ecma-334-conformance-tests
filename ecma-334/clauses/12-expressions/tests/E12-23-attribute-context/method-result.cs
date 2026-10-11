/*
Rules: E12-23-attribute-context
Authority: ECMA-334 7th ed 12.23
Version: 7.3
Expected: reject
Mutate: [Numeric(Program.Compute())]
Into: [Numeric(7)]
Csc: CS0182
*/
using System;
class NumericAttribute : Attribute
{
    public NumericAttribute(int number) { }
}
[Numeric(Program.Compute())]
class Marked { }
class Program
{
    public static int Compute() { return 7; }
    static void Main() { }
}
