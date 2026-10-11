/*
Rules: E15-3-5-hiding-declaration; E15-3-5-implicit-hiding-permitted
Authority: ECMA-334 7th ed 15.3.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public int Read() { return 383; }
Into: public int Other() { return 383; }
*/
using System;
class Parent { public int Read() { return 379; } }
class Child : Parent { public int Read() { return 383; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Child value = new Child();
        Parent parent = value;
        Check(value.Read() == 383, "implicit-hiding-is-legal-and-selects-derived-declaration");
        Check(parent.Read() == 379, "hidden-base-method-still-callable");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
