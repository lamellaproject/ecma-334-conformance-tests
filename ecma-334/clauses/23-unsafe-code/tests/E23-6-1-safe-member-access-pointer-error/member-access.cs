/*
Rules: E23-6-1-safe-member-access-pointer-error; E23-6-1-pointer-expression-safe-error
Authority: ECMA-334 7th ed 23.6.1
Version: 7.3
Expected: reject
Mutate: static void Main()
Into: static unsafe void Main()
*/
using System;
unsafe class Item { public int* Pointer; }
class Program
{
    static void Main()
    {
        Item item = new Item();
        bool empty = item.Pointer == null;
    }
}
