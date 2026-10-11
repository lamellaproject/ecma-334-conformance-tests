/*
Rules: E23-8-3-no-other-moveable-buffer-access
Authority: ECMA-334 7th ed 23.8.3
Version: 7.3
Expected: reject
Mutate: short* pointer = owner.Data.Values;
Into: fixed (short* pointer = owner.Data.Values) { }
*/
using System;
unsafe struct Data { public fixed short Values[2]; }
class Item { public Data Data; }
class Program
{
    static unsafe void Main()
    {
        Item owner = new Item();
        short* pointer = owner.Data.Values;
    }
}
