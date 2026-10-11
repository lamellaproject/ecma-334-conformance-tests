/*
Rules: E22-4-2-constructor-public
Authority: ECMA-334 7th ed 22.4.2
Version: 7.3
Expected: reject
Mutate: private MarkAttribute()
Into: public MarkAttribute()
*/
using System;
class MarkAttribute : Attribute { private MarkAttribute() { } }
[Mark] class Item { }
class Program
{
    static void Main()
    {

    }
}
