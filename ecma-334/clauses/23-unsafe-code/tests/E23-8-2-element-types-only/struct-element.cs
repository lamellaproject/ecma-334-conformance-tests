/*
Rules: E23-8-2-element-types-only
Authority: ECMA-334 7th ed 23.8.2
Version: 7.3
Expected: reject
Mutate: public fixed Data Values[2];
Into: public fixed int Values[2];
*/
using System;
struct Data { public int Value; }
unsafe struct Item { public fixed Data Values[2]; }
class Program
{
    static void Main()
    {

    }
}
