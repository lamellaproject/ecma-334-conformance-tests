/*
Rules: E12-17-simple-discard-lookup; E12-17-simple-discard-equivalence; E12-17-discard-assignment; E12-17-implicit-classification; E12-17-implicit-no-type; E12-17-infer-assignment-type
Authority: ECMA-334 7th ed 12.17
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: _ = Make(17);
Into: int _ = Make(17);
*/
using System;
class Box { }
class Program
{
    static string trace = "";
    static int Make(int n) { trace += "I"; return n; }
    static Box MakeBox() { trace += "B"; return new Box(); }
    static int Kind(Box x) { return 1; } static int Kind(object x) { return 2; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        _ = Make(17); Check(trace == "I", "simple-discard-evaluates-right");
        var value = (_ = MakeBox()); Check(Kind(value) == 1 && trace == "IB", "discard-does-not-bind-name-and-infers-right-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
