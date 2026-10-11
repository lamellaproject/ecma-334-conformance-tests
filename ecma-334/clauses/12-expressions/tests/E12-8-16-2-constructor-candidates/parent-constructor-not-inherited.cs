/*
Rules: E12-8-16-2-constructor-candidates; E12-8-16-2-no-constructor
Authority: ECMA-334 7th ed 12.8.16.2
Version: 7.3
Expected: reject
Mutate: new Child(9)
Into: new Child()
Csc: CS1729
*/
using System;
class Parent { public Parent(int number) { } }
class Child : Parent { public Child() : base(3) { } }
class Program
{
    static void Main() { var result = new Child(9); Console.WriteLine(result != null); }
}
