/*
Rules: E12-8-16-4-add-overload
Authority: ECMA-334 7th ed 12.8.16.4
Version: 7.3
Expected: reject
Mutate: new Bag { null }
Into: new Bag { (ILeft)null }
Csc: CS0121
*/
using System;
using System.Collections;
interface ILeft { }
interface IRight { }
class Bag : IEnumerable
{
    public void Add(ILeft value) { }
    public void Add(IRight value) { }
    public IEnumerator GetEnumerator() { return null; }
}
class Program
{
    static void Main() { var value = new Bag { null }; Console.WriteLine(value != null); }
}
