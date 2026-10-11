/*
Rules: E23-8-2-unsafe-context-only
Authority: ECMA-334 7th ed 23.8.2
Version: 7.3
Expected: reject
Mutate: struct Item
Into: unsafe struct Item
*/
using System;
struct Item { public fixed int Values[2]; }
class Program
{
    static void Main()
    {

    }
}
