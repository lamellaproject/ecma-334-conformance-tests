/*
Rules: E15-2-2-3-partial-sealed
Authority: ECMA-334 7th ed 15.2.2.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: partial class Root { }
Into: sealed partial class Root { }
*/
using System;
partial class Root { }
partial class Root { public int Read() { return 137; } }
class Leaf : Root { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Leaf().Read() == 137, "partial-with-no-sealed-part");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
