/*
Rules: E23-8-3-buffer-element-access-unsafe; E23-8-3-member-unsafe-required
Authority: ECMA-334 7th ed 23.8.3
Version: 7.3
Expected: reject
Mutate: static void Main()
Into: static unsafe void Main()
*/
using System;
unsafe struct Item { public fixed int Values[2]; }
class Program
{
    static void Main()
    {
        Item value = new Item();
        int result = value.Values[0];
    }
}
