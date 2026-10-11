/*
Rules: E22-2-4-parameter-types-only; E22-2-4-constructor-argument-type; E22-3-argument-type
Authority: ECMA-334 7th ed 22.2.4
Version: 7.3
Expected: reject
Mutate: public MarkAttribute(decimal value)
Into: public MarkAttribute(int value)
*/
using System;
class MarkAttribute : Attribute { public MarkAttribute(decimal value) { } }
[Mark(5)] class Item { }
class Program
{
    static void Main()
    {

    }
}
