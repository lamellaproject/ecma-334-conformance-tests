/*
Rules: E15-3-9-4-nested-hiding; E15-3-9-4-nested-new
Authority: ECMA-334 7th ed 15.3.9.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public new class Leaf
Into: public new class Other
*/
using System;
class Root { public class Leaf { public static int Read() { return 337; } } }
class Branch : Root { public new class Leaf { public static int Read() { return 347; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Root.Leaf.Read() == 337, "base-qualified-nested-type");
        Check(Branch.Leaf.Read() == 347, "derived-new-nested-type-hides-base");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
