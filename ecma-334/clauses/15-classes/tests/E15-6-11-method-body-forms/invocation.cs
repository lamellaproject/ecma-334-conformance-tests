/*
Rules: E15-6-11-method-body-forms; E15-6-11-implemented-body-execution; E15-6-11-effective-return-nonasync
Authority: ECMA-334 7th ed 15.6.11
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: trace += "b";
Into: trace += "x";
*/
using System;
abstract class Deferred { public abstract int Read(); public static extern void Send(); }
class Program
{
    static string trace = "";
    static int Block() { trace += "b"; return 18; }
    static int Expression() => Block() + 3;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Block() == 18 && trace == "b", "block-body");
        Check(Expression() == 21 && trace == "bb", "expression-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
