/*
Rules: E10-2-8-object; E10-2-8-identity-preserved
Authority: ECMA-334 7th ed 10.2.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: object result = source;
Into: object result = new object();
*/
using System;
class Receiver { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Receiver source = new Receiver();
        object result = source;
        Check(object.ReferenceEquals(result, source), "reference-identity/same-object");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
