/*
Rules: E13-13-lock-acquisition-flag
Authority: ECMA-334 7th ed 13.13
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: lock ((object)null)
Into: lock (new object())
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }

    static void Main()
    {
        bool entered = false, correct = false;
        try { lock ((object)null) { entered = true; } }
        catch (ArgumentNullException) { correct = true; }
        catch (Exception) { }
        Check(correct && !entered, "failed-enter-preserves-exception-and-skips-exit");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
