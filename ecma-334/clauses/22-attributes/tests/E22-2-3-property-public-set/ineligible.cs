/*
Rules: E22-2-3-property-public-set
Authority: ECMA-334 7th ed 22.2.3
Version: 7.3
Expected: reject
Mutate: private set;
Into: set;
*/
using System;
class MarkAttribute : Attribute { public int Value { get; private set; } }
[Mark(Value = 1)] class Item { }
class Program
{
    static void Main()
    {

    }
}
