/*
Rules: E23-8-2-no-static
Authority: ECMA-334 7th ed 23.8.2
Version: 7.3
Expected: reject
Mutate: public static fixed
Into: public fixed
*/
using System;
unsafe struct Item { public static fixed int Values[2]; }
class Program
{
    static void Main()
    {

    }
}
