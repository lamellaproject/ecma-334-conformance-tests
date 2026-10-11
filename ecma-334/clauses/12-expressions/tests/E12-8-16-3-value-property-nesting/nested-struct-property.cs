/*
Rules: E12-8-16-3-value-property-nesting
Authority: ECMA-334 7th ed 12.8.16.3
Version: 7.3
Expected: reject
Mutate: Property = { Value = 11 }
Into: Property = new Cell { Value = 11 }
Csc: CS1918
*/
using System;
struct Cell { public int Value; }
class Shell { public Cell Property { get; set; } }
class Program
{
    static void Main() { var value = new Shell { Property = { Value = 11 } }; Console.WriteLine(value.Property.Value); }
}
