/*
Rules: E12-8-16-2-abstract-type
Authority: ECMA-334 7th ed 12.8.16.2
Version: 7.3
Expected: reject
Mutate: new Shape()
Into: new Solid()
Csc: CS0144
*/
using System;
abstract class Shape { }
class Solid : Shape { }
class Program
{
    static void Main() { Shape value = new Shape(); Console.WriteLine(value != null); }
}
