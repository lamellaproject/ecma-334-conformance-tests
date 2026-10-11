/*
Rules: E7-9-eligible-finalizer-execution; E7-9-object-no-longer-in-use; E7-9-object-finalization-eligibility; E7-9-finalizer-time-unspecified; E7-9-finalizer-time-no-constraint; E7-9-finalizer-once-normal; E7-9-gc-static-control; E7-9-gc-request-finalizers
Authority: ECMA-334 7th ed 7.9
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: ~Token() { Calls++; }
Into: ~Token() { Calls += 2; }
*/
using System;
using System.Runtime.CompilerServices;
class Token
{
    public static int Calls;
    ~Token() { Calls++; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void Release() { new Token(); }
    static void Main()
    {
        Release();
        // No nonfinalizer continuation can reach the instance after Release returns.
        // Requests and their completion barrier observe finalization; there is no elapsed-time oracle.
        while (Token.Calls == 0) { GC.Collect(); GC.WaitForPendingFinalizers(); }
        Check(Token.Calls == 1, "eligible-unreachable-instance-finalizer-runs-once");
        GC.Collect(); GC.WaitForPendingFinalizers();
        GC.Collect(); GC.WaitForPendingFinalizers();
        Check(Token.Calls == 1, "later-requests-do-not-finalize-same-instance-again");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
