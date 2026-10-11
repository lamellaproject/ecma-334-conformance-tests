/*
Rules: E15-13-finalizer-void-method-body
Authority: ECMA-334 7th ed 15.13
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: if (N == 13) return;
Into: if (N == 13) return 7;
*/
using System;
using System.Runtime.CompilerServices;
class Gauge
{
    public int N = 13;
    ~Gauge() { Program.Saved = this.N; if (N == 13) return; Program.Saved = -1; }
}
class Program
{
    static int checks, failures;
    public static int Saved;
    static Gauge Held;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    // A separate frame prevents a construction temporary from extending the object's lifetime.
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void CreateAndRelease()
    {
        Held = new Gauge();
        Held = null;
    }
    static void Main()
    {
        CreateAndRelease();
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Check(Saved == 13, "finalizer-void-return-and-this");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
