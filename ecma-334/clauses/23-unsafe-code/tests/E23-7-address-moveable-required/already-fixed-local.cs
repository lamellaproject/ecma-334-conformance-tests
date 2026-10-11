/*
Rules: E23-7-address-moveable-required
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: reject
Mutate: fixed (int* pointer = &local)
Into: fixed (int* pointer = &owner.Value)
*/
using System;
class Item { public int Value; }
class Program
{
    static unsafe void Main()
    {
        int local = 7;
        Item owner = new Item();
        fixed (int* pointer = &local) { }
    }
}
