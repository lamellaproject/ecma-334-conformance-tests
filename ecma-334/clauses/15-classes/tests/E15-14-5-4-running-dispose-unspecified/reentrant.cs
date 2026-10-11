/*
Rules: E15-14-5-4-running-dispose-unspecified
Authority: ECMA-334 7th ed 15.14.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Active.Dispose();
Into: Active.Dispose(13);
*/
using System;
using System.Collections.Generic;
class Program
{
    static int checks, failures;
    static int Probes;
    static IEnumerator<int> Active;
    static IEnumerator<int> Sequence()
    {
        // Dispose while running has no prescribed result or exception; observe only completion.
        try { Active.Dispose(); }
        catch (Exception) { }
        Probes++;
        yield return 13;
    }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Active = Sequence();
        try { Active.MoveNext(); }
        catch (Exception) { }
        Check(Probes == 1, "running-dispose-completes-with-unrestricted-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
