/*
Rules: E23-8-2-no-repeated-modifier
Authority: ECMA-334 7th ed 23.8.2
Version: 7.3
Expected: reject
Mutate: public public fixed
Into: public fixed
*/
using System;
unsafe struct Item { public public fixed int Values[2]; }
class Program
{
    static void Main()
    {

    }
}
