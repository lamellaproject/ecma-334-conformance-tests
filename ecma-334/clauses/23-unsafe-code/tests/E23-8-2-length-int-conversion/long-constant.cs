/*
Rules: E23-8-2-length-int-conversion
Authority: ECMA-334 7th ed 23.8.2
Version: 7.3
Expected: reject
Mutate: Values[3L]
Into: Values[3]
*/
using System;
unsafe struct Item { public fixed int Values[3L]; }
class Program
{
    static void Main()
    {

    }
}
