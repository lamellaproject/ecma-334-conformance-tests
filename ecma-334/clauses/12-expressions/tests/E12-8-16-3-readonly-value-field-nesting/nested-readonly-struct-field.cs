/*
Rules: E12-8-16-3-readonly-value-field-nesting
Authority: ECMA-334 7th ed 12.8.16.3
Version: 7.3
Expected: reject
Mutate: public readonly Cell Field;
Into: public Cell Field;
Csc: CS1917
*/
using System;
struct Cell { public int Value; }
class Shell { public readonly Cell Field; }
class Program
{
    static void Main() { var value = new Shell { Field = { Value = 11 } }; Console.WriteLine(value.Field.Value); }
}
