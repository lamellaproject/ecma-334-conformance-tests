/*
Rules: E22-5-2-attributeusage-only-attribute-class
Authority: ECMA-334 7th ed 22.5.2
Version: 7.3
Expected: reject
Mutate: class Item { }
Into: class Item : Attribute { }
*/
using System;
[AttributeUsage(AttributeTargets.Class)] class Item { }
class Program
{
    static void Main()
    {

    }
}
