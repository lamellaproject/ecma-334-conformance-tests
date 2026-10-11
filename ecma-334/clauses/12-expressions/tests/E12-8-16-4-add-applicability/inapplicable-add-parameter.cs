/*
Rules: E12-8-16-4-add-applicability
Authority: ECMA-334 7th ed 12.8.16.4
Version: 7.3
Expected: reject
Mutate: new Bag { "bad" }
Into: new Bag { 7 }
Csc: CS1950
*/
using System;
using System.Collections;
class Bag : IEnumerable
{
    public void Add(int value) { }
    public IEnumerator GetEnumerator() { return null; }
}
class Program
{
    static void Main() { var value = new Bag { "bad" }; Console.WriteLine(value != null); }
}
