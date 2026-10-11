/*
Rules: E15-14-5-2-running-movenext-unspecified
Authority: ECMA-334 7th ed 15.14.5.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: bool ignored = Active.MoveNext();
Into: bool ignored = Active.MoveNext(13);
*/
using System;
using System.Collections.Generic;
class Program
{
    static int checks, failures;
    static IEnumerator<int> Active;
    static bool Entered;
    static int Probes;
    static IEnumerator<int> Sequence()
    {
        if (!Entered)
        {
            Entered = true;
            // No value or exception is prescribed for reentrant MoveNext; observe only completion.
            try { bool ignored = Active.MoveNext(); }
            catch (Exception) { }
            Probes++;
        }
        yield return 13;
    }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Active = Sequence();
        try { Active.MoveNext(); }
        catch (Exception) { }
        Check(Probes == 1, "running-movenext-completes-with-unrestricted-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
