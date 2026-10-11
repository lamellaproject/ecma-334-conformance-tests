/*
Rules: E15-14-5-2-yield-return-evaluate; E15-14-5-2-yield-return-convert; E15-14-5-2-yield-return-set-current; E15-14-5-2-yield-return-movenext-true
Authority: ECMA-334 7th ed 15.14.5.2
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: yield return Produce();
Into: yield return 17;
*/
using System;
using System.Collections.Generic;
struct Payload
{
    public int N;
    public static implicit operator int(Payload p) { Program.Trace += "C"; Program.Conversions++; return p.N; }
}
class Program
{
    static int checks, failures;
    public static int Evaluations, Conversions;
    public static string Trace = "";
    static Payload Produce() { Evaluations++; Trace += "E"; return new Payload { N = 13 }; }
    static IEnumerator<int> Sequence() { yield return Produce(); Trace += "R"; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IEnumerator<int> e = Sequence();
        Check(Evaluations == 0 && Conversions == 0, "yield-expression-not-evaluated-at-invocation");
        Check(e.MoveNext(), "converted-yield-returns-true");
        Check(Trace == "EC" && Evaluations == 1 && Conversions == 1, "evaluate-once-before-implicit-conversion-once");
        Check(e.Current == 13, "current-receives-converted-yield-value");
        Check(!e.MoveNext() && Trace == "ECR", "resume-after-expression-without-repeating-it");
        e.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
