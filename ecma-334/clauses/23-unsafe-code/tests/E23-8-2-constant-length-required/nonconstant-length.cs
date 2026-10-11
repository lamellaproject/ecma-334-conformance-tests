/*
Rules: E23-8-2-constant-length-required
Authority: ECMA-334 7th ed 23.8.2
Version: 7.3
Expected: reject
Mutate: public static int Count = 3;
Into: public const int Count = 3;
*/
using System;
unsafe struct Item { public static int Count = 3; public fixed int Values[Count]; }
class Program
{
    static void Main()
    {

    }
}
