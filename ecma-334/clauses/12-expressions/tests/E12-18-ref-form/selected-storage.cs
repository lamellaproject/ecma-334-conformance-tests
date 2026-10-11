/*
Rules: E12-18-ref-form; E12-18-ref-result-reference; E12-18-ref-result-type; E12-18-ref-result-writeability; E12-18-ref-condition-first; E12-18-ref-true-arm; E12-18-ref-false-arm; E12-18-one-arm-only
Authority: ECMA-334 7th ed 12.18
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Pick(true) ? ref Left() : ref Right()
Into: Pick(true) ? ref Right() : ref Left()
*/
using System;
class Program
{
    static string trace = "";
    static int left = 5, right = 9;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool Pick(bool value) { trace += "B"; return value; }
    static ref int Left() { trace += "L"; return ref left; }
    static ref int Right() { trace += "R"; return ref right; }
    static void Main()
    {
        ref int first = ref (Pick(true) ? ref Left() : ref Right());
        Check(trace == "BL" && first == 5, "true-condition-before-only-left");
        first = 17;
        Check(left == 17 && right == 9, "true-result-alias-write");
        trace = "";
        ref int second = ref (Pick(false) ? ref Left() : ref Right());
        Check(trace == "BR" && second == 9, "false-condition-before-only-right");
        second = 23;
        Check(left == 17 && right == 23, "false-result-alias-write");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
