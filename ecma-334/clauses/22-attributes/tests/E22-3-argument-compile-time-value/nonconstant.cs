/*
Rules: E22-3-argument-compile-time-value; E22-4-2-metadata-resolved-values
Authority: ECMA-334 7th ed 22.3
Version: 7.3
Expected: reject
Mutate: [Mark(Item.Value)]
Into: [Mark(7)]
*/
using System;
class MarkAttribute : Attribute { public MarkAttribute(int x) { } }
[Mark(Item.Value)] class Item { public static int Value = 7; }
class Program
{
    static void Main()
    {

    }
}
