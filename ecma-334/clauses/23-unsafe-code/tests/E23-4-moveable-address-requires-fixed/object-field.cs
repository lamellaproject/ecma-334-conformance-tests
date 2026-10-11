/*
Rules: E23-4-moveable-address-requires-fixed; E23-4-other-variables-moveable
Authority: ECMA-334 7th ed 23.4
Version: 7.3
Expected: reject
Mutate: int* p = &item.Value;
Into: fixed (int* p = &item.Value) { }
Csc: CS0212
*/
using System;
class Item { public int Value; }
class Program
{
    static unsafe void Main()
    {
        Item item = new Item();
        int* p = &item.Value;
    }
}
