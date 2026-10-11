/*
Rules: E23-8-3-no-value-receiver
Authority: ECMA-334 7th ed 23.8.3
Version: 7.3
Expected: reject
Mutate: int result = Create().Values[0];
Into: Item value = Create(); int result = value.Values[0];
*/
using System;
unsafe struct Item { public fixed int Values[2]; }
class Program
{
    static Item Create() { return new Item(); }
    static unsafe void Main()
    {
        int result = Create().Values[0];
    }
}
