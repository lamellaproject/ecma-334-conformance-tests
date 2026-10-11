/*
Rules: E23-8-2-length-positive
Authority: ECMA-334 7th ed 23.8.2
Version: 7.3
Expected: reject
Mutate: Values[0]
Into: Values[1]
*/
using System;
unsafe struct Item { public fixed int Values[0]; }
class Program
{
    static void Main()
    {

    }
}
