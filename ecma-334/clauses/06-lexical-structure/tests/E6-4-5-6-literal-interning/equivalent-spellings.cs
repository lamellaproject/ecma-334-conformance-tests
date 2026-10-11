/*
Rules: E6-4-5-6-literal-interning
Authority: ECMA-334 7th ed 6.4.5.6
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: return "b\u0061y";
Into: return "b\u0061t";
*/
using System;
class Peer { public static string Text() { return "b\u0061y"; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object regular = "bay";
        object verbatim = @"bay";
        Check(object.ReferenceEquals(regular, verbatim), "different-spelling-same-instance");
        Check(object.ReferenceEquals(regular, Peer.Text()), "different-type-same-assembly");
        Check(!object.ReferenceEquals(regular, "bat"), "unequal-literals");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
