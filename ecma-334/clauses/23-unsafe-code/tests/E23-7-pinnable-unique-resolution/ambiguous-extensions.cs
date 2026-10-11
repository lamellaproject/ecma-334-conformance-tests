/*
Rules: E23-7-pinnable-unique-resolution
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: reject
Mutate: static class Right { public static ref int GetPinnableReference(this Item item)
Into: static class Right { public static ref int Other(this Item item)
*/
using System;
class Item { public int Value; }
static class Left { public static ref int GetPinnableReference(this Item item) { return ref item.Value; } }
static class Right { public static ref int GetPinnableReference(this Item item) { return ref item.Value; } }
class Program
{
    static unsafe void Main()
    {
        Item source = new Item();
        fixed (int* pointer = source) { }
    }
}
