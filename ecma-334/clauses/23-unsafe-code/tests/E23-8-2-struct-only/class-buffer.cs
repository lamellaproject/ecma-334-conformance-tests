/*
Rules: E23-8-2-struct-only
Authority: ECMA-334 7th ed 23.8.2
Version: 7.3
Expected: reject
Mutate: unsafe class Item
Into: unsafe struct Item
*/
using System;
unsafe class Item { public fixed int Values[2]; }
class Program
{
    static void Main()
    {

    }
}
