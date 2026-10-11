/*
Rules: E23-7-pinnable-method-required
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: reject
Mutate: public ref int Other()
Into: public ref int GetPinnableReference()
*/
using System;
class Item { public int Value; public ref int Other() { return ref Value; } }
class Program
{
    static unsafe void Main()
    {
        Item source = new Item();
        fixed (int* pointer = source) { }
    }
}
