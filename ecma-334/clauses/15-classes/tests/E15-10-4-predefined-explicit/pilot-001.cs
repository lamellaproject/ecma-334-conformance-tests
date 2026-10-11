/*
Rules: E15-10-4-predefined-explicit
Authority: ECMA-334 7th ed 15.10.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Parent<Child> baseValue=source;
Into: Parent<Child> baseValue=default(Parent<Child>);
*/
using System;


class Parent<T> {public static int Calls;public static explicit operator T(Parent<T> x){Calls++;return default(T);}}
class Child:Parent<Child> {}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Child source=new Child(); Parent<Child> baseValue=source;
        Child result=(Child)baseValue;
        Check(ReferenceEquals(source,result) && Parent<Child>.Calls==0, "E15-10-4-predefined-explicit-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
