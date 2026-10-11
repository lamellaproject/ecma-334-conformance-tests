/*
Rules: E12-8-16-4-enumerable-required
Authority: ECMA-334 7th ed 12.8.16.4
Version: 7.3
Expected: reject
Mutate: class Bag
Into: class Bag : IEnumerable
Csc: CS1922
*/
using System;
using System.Collections;
class Bag
{
    public void Add(int value) { }
    public IEnumerator GetEnumerator() { return null; }
}
class Program
{
    static void Main() { var value = new Bag { 7 }; Console.WriteLine(value != null); }
}
