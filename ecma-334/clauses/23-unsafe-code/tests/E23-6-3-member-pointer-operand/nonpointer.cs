/*
Rules: E23-6-3-member-pointer-operand
Authority: ECMA-334 7th ed 23.6.3
Version: 7.3
Expected: reject
Mutate: int result = value->Value;
Into: int result = (&value)->Value;
*/
using System;
struct Item { public int Value; }
class Program
{
    static unsafe void Main()
    {
        Item value = new Item();
        int result = value->Value;
    }
}
