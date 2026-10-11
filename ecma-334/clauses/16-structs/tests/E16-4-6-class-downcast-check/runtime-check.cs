/*
Rules: E16-4-6-class-downcast-check
Authority: ECMA-334 7th ed 16.4.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: (Child)source
Into: new Child()
*/
using System;
class Parent { }
class Child : Parent { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Parent source = new Parent(); bool correct = false;
        try { Child result = (Child)source; }
        catch (InvalidCastException) { correct = true; }
        catch (Exception) { }
        Check(correct, "downcast-runtime-type-check");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
