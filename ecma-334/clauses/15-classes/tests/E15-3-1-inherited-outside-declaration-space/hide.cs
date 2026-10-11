/*
Rules: E15-3-1-inherited-outside-declaration-space
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public new int Number = 239;
Into: 
*/
using System;
class Parent { public int Number = 241; }
class Child : Parent { public new int Number = 239; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Child value = new Child();
        Check(value.Number == 239, "declared-name-may-match-inherited-name");
        Check(((Parent)value).Number == 241, "base-declaration-remains-separate");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
