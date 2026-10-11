/*
Rules: E22-3-ambiguous-attribute-candidates
Authority: ECMA-334 7th ed 22.3
Version: 7.3
Expected: reject
Mutate: [Tag]
Into: [@Tag]
*/
using System;
class Tag : Attribute { }
class TagAttribute : Attribute { }
[Tag] class Item { }
class Program
{
    static void Main()
    {

    }
}
