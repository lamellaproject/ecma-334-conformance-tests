/*
Rules: E20-2-modifier-new; E20-2-new-hides
Authority: ECMA-334 7th ed 20.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public new delegate void Read();
Into: public new delegate int Read();
*/
using System;
class Root { public delegate int Read(); }
class Branch : Root { public new delegate void Read(); }
class Program
{
    static int checks, failures;
    static int calls;
    static int ReadValue() { return 41; }
    static void Hit() { calls++; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Root.Read root = ReadValue;
        Branch.Read branch = Hit;
        branch();
        Check(root() == 41, "base-qualified-delegate");
        Check(calls == 1, "derived-name-hides-base-delegate");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
