/*
Rules: E23-6-5-address-no-moveable
Authority: ECMA-334 7th ed 23.6.5
Version: 7.3
Expected: reject
Mutate: int* pointer = &value.Value;
Into: fixed (int* pointer = &value.Value) { }
*/
using System;
class Item { public int Value; }
class Program
{
    static unsafe void Main()
    {
        Item value = new Item();
        int* pointer = &value.Value;
    }
}
