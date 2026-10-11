/*
Rules: E22-3-positional-before-named
Authority: ECMA-334 7th ed 22.3
Version: 7.3
Expected: reject
Mutate: [Mark(Value = 7, 9)]
Into: [Mark(9, Value = 7)]
*/
using System;
class MarkAttribute : Attribute { public int Value; public MarkAttribute(int x) { } }
[Mark(Value = 7, 9)] class Item { }
class Program
{
    static void Main()
    {

    }
}
