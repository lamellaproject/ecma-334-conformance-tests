/*
Rules: E15-13-finalizer-chain-order
Authority: ECMA-334 7th ed 15.13
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: ~Leaf() { Program.Trace = Program.Trace * 10 + 3; }
Into: ~Leaf() { }
*/
using System;
using System.Runtime.CompilerServices;
class Root { ~Root() { Program.Trace = Program.Trace * 10 + 1; } }
class Middle : Root { ~Middle() { Program.Trace = Program.Trace * 10 + 2; } }
class Leaf : Middle { ~Leaf() { Program.Trace = Program.Trace * 10 + 3; } }
class Program
{
    static int checks, failures;
    public static int Trace;
    static Root Held;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    // A separate frame prevents a construction temporary from extending the object's lifetime.
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void CreateAndRelease()
    {
        Held = new Leaf();
        Held = null;
    }
    static void Main()
    {
        CreateAndRelease();
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Check(Trace == 321, "derived-middle-base-finalizer-order");
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Check(Trace == 321, "chain-not-repeated-by-collection");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
