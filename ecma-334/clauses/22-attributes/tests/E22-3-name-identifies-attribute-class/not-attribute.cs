/*
Rules: E22-3-name-identifies-attribute-class; E22-3-no-attribute-candidate
Authority: ECMA-334 7th ed 22.3
Version: 7.3
Expected: reject
Mutate: class Plain { }
Into: class Plain : Attribute { }
*/
using System;
class Plain { }
[Plain] class Item { }
class Program
{
    static void Main()
    {

    }
}
