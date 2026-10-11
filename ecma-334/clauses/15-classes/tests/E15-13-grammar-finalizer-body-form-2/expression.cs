/*
Rules: E15-13-grammar-finalizer-body-form-2; E15-13-finalizer-expression-execution
Authority: ECMA-334 7th ed 15.13
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: ~Gauge() => Release();
Into: ~Gauge() => Program.Calls++;
*/
using System;
using System.Runtime.CompilerServices;
class Gauge
{
    public int N = 13;
    ~Gauge() => Release();
    void Release() { Program.Saved = this.N; Program.Calls++; }
}
class Program
{
    static int checks, failures;
    public static int Saved, Calls;
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
        Check(Saved == 13, "finalizer-expression-instance-value");
        Check(Calls == 1, "finalizer-expression-effect");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
