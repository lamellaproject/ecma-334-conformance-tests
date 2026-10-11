/*
Rules: E15-14-5-2-yield-return-save-parameters; E15-14-5-2-suspended-movenext-restore-parameters
Authority: ECMA-334 7th ed 15.14.5.2
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: n += 11;
Into: n = 11;
*/
using System;
using System.Collections.Generic;
class Program
{
    static int checks, failures;
    static IEnumerator<int> Sequence(int n) { n += 7; yield return n; n += 11; yield return n; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int argument = 13;
        IEnumerator<int> e = Sequence(argument);
        Check(e.MoveNext(), "parameter-first-yield");
        Check(e.Current == 20, "parameter-modified-before-suspension");
        argument = 23;
        Check(e.MoveNext(), "parameter-second-yield");
        Check(e.Current == 31 && argument == 23, "modified-parameter-saved-across-suspension");
        Check(!e.MoveNext(), "parameter-iterator-end");
        e.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
