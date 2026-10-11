/*
Rules: E15-14-5-2-before-movenext-restore-arguments; E15-14-5-2-before-movenext-start-block; E15-14-5-2-movenext-block-current
Authority: ECMA-334 7th ed 15.14.5.2
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: yield return n + this.N;
Into: yield return n;
*/
using System;
using System.Collections.Generic;
class Gauge
{
    public int N;
    public IEnumerator<int> Sequence(int n) { Program.Trace += "S"; yield return n + this.N; Program.Trace += "E"; }
}
class Program
{
    static int checks, failures;
    public static string Trace = "";
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge original = new Gauge { N = 7 };
        Gauge receiver = original;
        int argument = 6;
        IEnumerator<int> e = receiver.Sequence(argument);
        receiver = new Gauge { N = 23 };
        argument = 19;
        Check(Trace == "", "before-movenext-has-not-entered-block");
        Check(e.MoveNext(), "before-movenext-yields");
        Check(e.Current == 13 && Trace == "S" && argument == 19 && receiver.N == 23, "initial-parameters-and-this-from-saved-values");
        Check(!e.MoveNext() && Trace == "SE", "initial-entry-before-resumption");
        e.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
