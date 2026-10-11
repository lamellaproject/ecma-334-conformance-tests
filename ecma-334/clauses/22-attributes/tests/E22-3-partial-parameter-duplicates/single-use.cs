/*
Rules: E22-3-partial-parameter-duplicates
Authority: ECMA-334 7th ed 22.3
Version: 7.3
Expected: reject
Mutate: partial class Item<[Mark] T> { public int Value; }
Into: partial class Item<T> { public int Value; }
*/
using System;
class MarkAttribute : Attribute { }
partial class Item<[Mark] T> { }
partial class Item<[Mark] T> { public int Value; }
class Program
{
    static void Main()
    {

    }
}
