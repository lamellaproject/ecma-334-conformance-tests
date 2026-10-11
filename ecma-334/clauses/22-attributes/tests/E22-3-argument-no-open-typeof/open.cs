/*
Rules: E22-3-argument-no-open-typeof
Authority: ECMA-334 7th ed 22.3
Version: 7.3
Expected: reject
Mutate: [Mark(typeof(Box<T>))]
Into: [Mark(typeof(Box<int>))]
*/
using System;
class Box<T> { }
class MarkAttribute : Attribute { public MarkAttribute(Type value) { } }
class Outer<T> { [Mark(typeof(Box<T>))] class Item { } }
class Program
{
    static void Main()
    {

    }
}
