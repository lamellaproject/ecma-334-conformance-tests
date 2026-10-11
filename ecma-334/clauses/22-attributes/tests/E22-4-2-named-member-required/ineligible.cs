/*
Rules: E22-4-2-named-member-required
Authority: ECMA-334 7th ed 22.4.2
Version: 7.3
Expected: reject
Mutate: public static int Value;
Into: public int Value;
*/
using System;
class MarkAttribute : Attribute { public static int Value; }
[Mark(Value = 1)] class Item { }
class Program
{
    static void Main()
    {

    }
}
