/*
Rules: E8-1-reference-object-view; E8-2-2-predefined-object-base
Authority: ECMA-334 7th ed 8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: object view = original;
Into: object view = new Receiver();
*/
using System;
class Receiver { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Receiver original = new Receiver();
        object view = original;
        Check(view == original, "reference-preserved-in-object-view");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
