/*
Rules: E22-2-4-public-field-type
Authority: ECMA-334 7th ed 22.2.4
Version: 7.3
Expected: reject
Mutate: public decimal Value;
Into: public int Value;
*/
using System;
class MarkAttribute : Attribute { public decimal Value; }
[Mark(Value = 5)] class Item { }
class Program
{
    static void Main()
    {

    }
}
