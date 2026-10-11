/*
Rules: E7-9-gc-request-finalizers; E7-9-gc-static-control
Authority: ECMA-334 7th ed 7.9
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: GC.SuppressFinalize(instance);
Into: GC.KeepAlive(instance);
*/
using System;
using System.Runtime.CompilerServices;
class Token { public static int Calls; ~Token() { Calls++; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void Release()
    {
        Token instance = new Token();
        GC.SuppressFinalize(instance);
    }
    static void Main()
    {
        Release(); GC.Collect(); GC.WaitForPendingFinalizers();
        Check(Token.Calls == 0, "suppression-request-prevents-finalizer-execution");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
