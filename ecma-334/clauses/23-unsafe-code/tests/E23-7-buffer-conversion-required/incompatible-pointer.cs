/*
Rules: E23-7-buffer-conversion-required
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: reject
Mutate: fixed (int* pointer = owner.Data.Values)
Into: fixed (short* pointer = owner.Data.Values)
*/
using System;
unsafe struct Data { public fixed short Values[3]; }
class Item { public Data Data; }
class Program
{
    static unsafe void Main()
    {
        Item owner = new Item();
        fixed (int* pointer = owner.Data.Values) { }
    }
}
