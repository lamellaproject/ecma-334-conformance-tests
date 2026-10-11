/*
Rules: E23-2-partial-type-context
Authority: ECMA-334 7th ed 23.2
Version: 7.3
Expected: reject
Mutate: partial class Item { public int* Other; }
Into: unsafe partial class Item { public int* Other; }
*/
using System;
unsafe partial class Item { public int* Pointer; }
partial class Item { public int* Other; }
class Program
{
    static void Main()
    {

    }
}
