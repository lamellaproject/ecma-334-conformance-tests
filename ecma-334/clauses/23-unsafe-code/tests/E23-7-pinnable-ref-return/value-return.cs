/*
Rules: E23-7-pinnable-ref-return
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: reject
Mutate: public int GetPinnableReference() { return Value; }
Into: public ref int GetPinnableReference() { return ref Value; }
*/
using System;
class Item { public int Value; public int GetPinnableReference() { return Value; } }
class Program
{
    static unsafe void Main()
    {
        Item source = new Item();
        fixed (int* pointer = source) { }
    }
}
