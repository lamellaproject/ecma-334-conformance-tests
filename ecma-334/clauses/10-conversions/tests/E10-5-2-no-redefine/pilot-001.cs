/*
Rules: E10-5-2-no-redefine; E10-5-2-predefined
Authority: ECMA-334 7th ed 10.5.2
Version: 7.3
Expected: reject
Mutate: class Child:Parent
Into: class Child
*/
using System;

class Child:Parent {public static implicit operator Parent(Child x){return x;}} class Parent {}
class Program
{
    static void Main()
    {

    }
}
