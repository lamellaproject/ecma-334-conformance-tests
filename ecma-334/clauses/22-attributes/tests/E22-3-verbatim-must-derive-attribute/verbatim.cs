/*
Rules: E22-3-verbatim-must-derive-attribute
Authority: ECMA-334 7th ed 22.3
Version: 7.3
Expected: reject
Mutate: [@Plain]
Into: [Plain]
*/
using System;
class Plain { }
class PlainAttribute : Attribute { }
[@Plain] class Item { }
class Program
{
    static void Main()
    {

    }
}
