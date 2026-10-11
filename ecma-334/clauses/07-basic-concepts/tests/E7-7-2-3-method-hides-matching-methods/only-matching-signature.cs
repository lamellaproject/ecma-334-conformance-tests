/*
Rules: E7-7-2-3-method-hides-matching-methods
Authority: ECMA-334 7th ed 7.7.2.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public new int Read(int value)
Into: public new int Renamed(int value)
*/
using System;
class Root { public int Read(int value) { return 83; } public int Read(string value) { return 89; } }
class Branch : Root { public new int Read(int value) { return 97; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Branch value = new Branch();
        Check(value.Read(5) == 97, "matching-base-signature-hidden");
        Check(value.Read("ash") == 89, "different-base-signature-still-visible");
        Check(((Root)value).Read(5) == 83, "hidden-method-through-base-receiver");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
