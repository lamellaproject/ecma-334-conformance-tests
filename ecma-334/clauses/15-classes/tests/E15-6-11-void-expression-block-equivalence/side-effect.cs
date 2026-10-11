/*
Rules: E15-6-11-void-expression-block-equivalence
Authority: ECMA-334 7th ed 15.6.11
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Expr() => Mark("e");
Into: Expr() => Mark("x");
*/
using System;
class Program
{
    static string trace = "";
    static void Mark(string text) { trace += text; }
    static void Expr() => Mark("e");
    static void Block() { Mark("e"); }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { Expr(); Block(); Check(trace == "ee", "void-expression-executed-once"); if (failures == 0) Console.WriteLine("OK " + checks); }
}
