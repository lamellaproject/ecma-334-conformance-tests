/*
Rules: E8-2-4-dynamic-any-object; E8-2-1-reference-form-dynamic; E8-2-1-nonarray-form-dynamic
Authority: ECMA-334 7th ed 8.2.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: dynamic[] items = { 23, "bound", new Receiver() };
Into: dynamic[] items = { 24, "bound", new Receiver() };
*/
using System;
class Receiver { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic[] items = { 23, "bound", new Receiver() }; object[] view = items;
        Check((int)view[0] == 23 && (string)view[1] == "bound" && view[2] is Receiver, "dynamic-references-different-object-types");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
