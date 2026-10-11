/*
Rules: E23-7-address-conversion-required
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: reject
Mutate: fixed (char* pointer = &owner.Value)
Into: fixed (int* pointer = &owner.Value)
*/
using System;
class Item { public int Value; }
class Program
{
    static unsafe void Main()
    {
        Item owner = new Item();
        fixed (char* pointer = &owner.Value) { }
    }
}
