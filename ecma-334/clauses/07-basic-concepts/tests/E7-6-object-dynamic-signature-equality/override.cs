/*
Rules: E7-6-object-dynamic-signature-equality; E7-6-signature-equality
Authority: ECMA-334 7th ed 7.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: override int Read(dynamic value)
Into: override int Read(string value)
*/
using System;
class Root { public virtual int Read(object value) { return 131; } }
class Branch : Root { public override int Read(dynamic value) { return 137; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Root value = new Branch();
        Check(value.Read(new object()) == 137, "object-and-dynamic-signatures-match-for-override");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
