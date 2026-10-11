/*
Rules: E15-13-finalizer-block-execution; E15-13-finalizer-instance-finalization; E15-13-finalizer-automatic-invocation; E15-13-finalization-eligibility; E15-13-finalization-time; E15-13-finalizer-thread
Authority: ECMA-334 7th ed 15.13
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: ~Gauge()
Into: public void Release()
*/
using System;
using System.Threading;
using System.Runtime.CompilerServices;
class Gauge
{
    public int N;
    public Gauge(int n) { N = n; }
    ~Gauge() { Program.Saved = N; Program.ObservedThread = Thread.CurrentThread; Program.Calls++; }
}
class Program
{
    static int checks, failures;
    public static int Saved, Calls;
    public static Thread ObservedThread;
    static Gauge Held;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    // Keep constructor and liveness-check temporaries out of the collecting caller's stack.
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void CreateAndRelease()
    {
        Held = new Gauge(13);
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Check(Calls == 0 && Held.N == 13, "reachable-instance-not-eligible");
        Held = null;
    }
    static void Main()
    {
        CreateAndRelease();
        // GC's explicit requests let this test observe finalization without prescribing spontaneous timing.
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Check(Calls == 1, "automatic-finalizer-ran-once");
        Check(Saved == 13, "finalizer-uses-instance-state");
        // 15.13 allows any thread; this observation imposes no caller-thread restriction.
        Check(ObservedThread != null, "finalizer-thread-observation-completed");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
