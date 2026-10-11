/*
Rules: E16-2-2-modifier-new
Authority: ECMA-334 7th ed 16.2.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new public struct Entry
Into: new public class Entry
*/
using System;
class Parent { public struct Entry { } }
class Child : Parent { new public struct Entry { } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool Value<T>() where T : struct { return true; }
    static void Main()
    {
        Check(Value<Parent.Entry>(), "base-nested-type");
        Check(Value<Child.Entry>(), "new-nested-struct");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
