/*
Rules: E23-7-pinnable-conversion-required
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: reject
Mutate: fixed (char* pointer = source)
Into: fixed (int* pointer = source)
*/
using System;
class Item { public int Value; public ref int GetPinnableReference() { return ref Value; } }
class Program
{
    static unsafe void Main()
    {
        Item source = new Item();
        fixed (char* pointer = source) { }
    }
}
