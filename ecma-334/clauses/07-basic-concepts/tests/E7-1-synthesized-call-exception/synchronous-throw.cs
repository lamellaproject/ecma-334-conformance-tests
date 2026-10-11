/*
Rules: E7-1-synthesized-call-exception
Authority: ECMA-334 7th ed 7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: if (probing) throw new EntryFailure();
Into: if (probing) return Task.CompletedTask;
*/
using System;
using System.Reflection;
using System.Threading.Tasks;
class EntryFailure : Exception { }
class Program
{
    static bool probing;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Task Main()
    {
        if (probing) throw new EntryFailure();
        probing = true;
        bool propagated = false;
        try { typeof(Program).Assembly.EntryPoint.Invoke(null, null); }
        catch (TargetInvocationException exception) { propagated = exception.InnerException is EntryFailure; }
        catch (Exception) { }
        Check(propagated, "synthesized-call-propagated-original-exception");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return Task.CompletedTask;
    }
}
