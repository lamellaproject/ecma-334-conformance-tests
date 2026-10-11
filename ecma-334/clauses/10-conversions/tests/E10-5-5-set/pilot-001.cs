/*
Rules: E10-5-5-set
Authority: ECMA-334 7th ed 10.5.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Child result=(Child)source;
Into: Child result=default(Child);
*/
using System;


struct Input {public int Number;}
class Parent {public int Number;public static int Calls;public static explicit operator Parent(Input x){Calls++;return new Child {Number=x.Number};}}
class Child:Parent {}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Input source=new Input {Number=61}; Child result=(Child)source;
        Check(result.Number==61 && Parent.Calls==1, "E10-5-5-set-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
