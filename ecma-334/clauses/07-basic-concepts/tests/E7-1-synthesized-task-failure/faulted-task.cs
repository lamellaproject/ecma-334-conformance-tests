/*
Rules: E7-1-synthesized-task-failure
Authority: ECMA-334 7th ed 7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Task.FromException(new EntryFailure())
Into: Task.CompletedTask
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
        if (probing) return Task.FromException(new EntryFailure());
        probing = true;
        bool propagated = false;
        try { typeof(Program).Assembly.EntryPoint.Invoke(null, null); }
        catch (TargetInvocationException exception) { propagated = exception.InnerException is EntryFailure; }
        catch (Exception) { }
        Check(propagated, "get-result-propagated-original-fault");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return Task.CompletedTask;
    }
}
