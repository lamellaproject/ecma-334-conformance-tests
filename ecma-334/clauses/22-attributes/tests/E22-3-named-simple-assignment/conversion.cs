/*
Rules: E22-3-named-simple-assignment
Authority: ECMA-334 7th ed 22.3
Version: 7.3
Expected: reject
Mutate: Value = "ink"
Into: Value = 7
*/
using System;
class MarkAttribute : Attribute { public int Value; }
[Mark(Value = "ink")] class Item { }
class Program
{
    static void Main()
    {

    }
}
