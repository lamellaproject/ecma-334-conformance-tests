/*
Rules: E12-8-16-3-nested-collection-type
Authority: ECMA-334 7th ed 12.8.16.3
Version: 7.3
Expected: reject
Mutate: public Plain Items = new Plain();
Into: public Bag Items = new Bag();
Csc: CS1922
*/
using System;
using System.Collections;
class Plain { public void Add(int value) { } }
class Bag : IEnumerable
{
    public void Add(int value) { }
    public IEnumerator GetEnumerator() { return null; }
}
class Shell { public Plain Items = new Plain(); }
class Program
{
    static void Main() { var value = new Shell { Items = { 7 } }; Console.WriteLine(value != null); }
}
