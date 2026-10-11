/*
Rules: E22-2-2-single-use-false; E22-3-single-use-duplicate
Authority: ECMA-334 7th ed 22.2.2
Version: 7.3
Expected: reject
Mutate: [Mark, Mark]
Into: [Mark]
*/
using System;
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)] class MarkAttribute : Attribute { }
[Mark, Mark] class Item { }
class Program
{
    static void Main()
    {

    }
}
