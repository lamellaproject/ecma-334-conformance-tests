/*
Rules: E12-8-16-4-add-method-group
Authority: ECMA-334 7th ed 12.8.16.4
Version: 7.3
Expected: reject
Mutate: public int Add;
Into: public void Add(int value) { }
Csc: CS1955
*/
using System;
using System.Collections;
class Bag : IEnumerable
{
    public int Add;
    public IEnumerator GetEnumerator() { return null; }
}
class Program
{
    static void Main() { var value = new Bag { 7 }; Console.WriteLine(value != null); }
}
