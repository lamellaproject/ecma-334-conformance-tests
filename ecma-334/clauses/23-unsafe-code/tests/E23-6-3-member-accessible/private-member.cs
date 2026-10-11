/*
Rules: E23-6-3-member-accessible
Authority: ECMA-334 7th ed 23.6.3
Version: 7.3
Expected: reject
Mutate: private int Value;
Into: public int Value;
*/
using System;
struct Item { private int Value; }
class Program
{
    static unsafe void Main()
    {
        Item value = new Item();
        Item* pointer = &value;
        int result = pointer->Value;
    }
}
