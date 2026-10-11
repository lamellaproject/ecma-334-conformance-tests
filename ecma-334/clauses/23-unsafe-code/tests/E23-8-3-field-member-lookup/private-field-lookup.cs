/*
Rules: E23-8-3-field-member-lookup
Authority: ECMA-334 7th ed 23.8.3
Version: 7.3
Expected: reject
Mutate: private fixed int Values[2];
Into: public fixed int Values[2];
*/
using System;
unsafe struct Item { private fixed int Values[2]; }
class Program
{
    static unsafe void Main()
    {
        Item value = new Item();
        int result = value.Values[0];
    }
}
