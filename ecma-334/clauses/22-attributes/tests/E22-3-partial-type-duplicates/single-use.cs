/*
Rules: E22-3-partial-type-duplicates
Authority: ECMA-334 7th ed 22.3
Version: 7.3
Expected: reject
Mutate: [Mark] partial class Item { public int Value; }
Into: partial class Item { public int Value; }
*/
using System;
class MarkAttribute : Attribute { }
[Mark] partial class Item { }
[Mark] partial class Item { public int Value; }
class Program
{
    static void Main()
    {

    }
}
