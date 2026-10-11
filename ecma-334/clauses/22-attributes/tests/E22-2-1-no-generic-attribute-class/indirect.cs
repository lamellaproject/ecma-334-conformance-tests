/*
Rules: E22-2-1-no-generic-attribute-class
Authority: ECMA-334 7th ed 22.2.1
Version: 7.3
Expected: reject
Mutate: class Tag<T>
Into: class Tag
*/
using System;
class Root : Attribute { }
class Tag<T> : Root { }
class Program
{
    static void Main()
    {

    }
}
