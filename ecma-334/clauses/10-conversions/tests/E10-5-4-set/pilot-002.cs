/*
Rules: E10-5-4-set; E10-5-4-empty
Authority: ECMA-334 7th ed 10.5.4
Version: 7.3
Expected: reject
Mutate: Child result=source;
Into: Child result=default(Child);
Csc: CS0266
*/
using System;


struct Input {}
class Parent {public static implicit operator Parent(Input x){return new Child();}}
class Child:Parent {}

class Program
{
    static void Main()
    {
        Input source=new Input(); Child result=source;
    }
}
