/*
Rules: E12-8-16-4-unbraced-assignment
Authority: ECMA-334 7th ed 12.8.16.4
Version: 7.3
Expected: reject
Mutate: new Bag { slot = 5 }
Into: new Bag { (slot = 5) }
Csc: CS0117
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
    static int slot;
    static void Main() { var value = new Bag { slot = 5 }; Console.WriteLine(slot); }
}
