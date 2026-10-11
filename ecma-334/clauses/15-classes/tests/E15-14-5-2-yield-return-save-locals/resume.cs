/*
Rules: E15-14-5-2-yield-return-save-locals; E15-14-5-2-suspended-movenext-restore-locals; E15-14-5-2-yield-return-save-location; E15-14-5-2-suspended-movenext-resume; E15-14-5-2-yield-return-suspend-body; E15-14-5-2-yield-return-suspended-state
Authority: ECMA-334 7th ed 15.14.5.2
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: local += 5;
Into: local = 5;
*/
using System;
using System.Collections.Generic;
class Program
{
    static int checks, failures;
    static string Trace = "";
    static IEnumerator<int> Sequence(int n)
    {
        int local = n + 3;
        Trace += "S";
        yield return local;
        Trace += "R";
        local += 5;
        yield return local;
        Trace += "E";
    }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IEnumerator<int> e = Sequence(2);
        Check(e.MoveNext(), "local-first-yield");
        Check(e.Current == 5 && Trace == "S", "first-yield-suspends-before-following-statements");
        Check(e.MoveNext(), "local-second-yield");
        Check(e.Current == 10 && Trace == "SR", "local-restored-and-resume-location-preserved");
        Check(!e.MoveNext() && Trace == "SRE", "second-yield-resumes-to-end");
        Check(!e.MoveNext() && Trace == "SRE", "after-state-keeps-body-ended");
        e.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
