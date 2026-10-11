/*
Rules: E19-3-modifier-protected; E19-3-class-modifier-meaning
Authority: ECMA-334 7th ed 19.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: protected enum Code
Into: private enum Code
*/
using System;
class Parent { protected enum Code { Mark = 11 } }
class Child : Parent { public static int Read() { return (int)Code.Mark; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Child.Read() == 11, "protected-enum-access-in-derived-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
