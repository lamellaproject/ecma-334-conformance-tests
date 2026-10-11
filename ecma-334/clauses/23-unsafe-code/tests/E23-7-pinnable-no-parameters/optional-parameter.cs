/*
Rules: E23-7-pinnable-no-parameters
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: reject
Mutate: GetPinnableReference(int ignored = 0)
Into: GetPinnableReference()
*/
using System;
class Item { public int Value; public ref int GetPinnableReference(int ignored = 0) { return ref Value; } }
class Program
{
    static unsafe void Main()
    {
        Item source = new Item();
        fixed (int* pointer = source) { }
    }
}
