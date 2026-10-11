/*
Rules: E12-8-19-parenthesized-equivalence
Authority: ECMA-334 7th ed 12.8.19
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: checked(Left() + Right())
Into: checked(Left()) + Right()
*/
using System;
class Program
{
    static string trace = "";
    static int Left() { trace += "L"; return 2; }
    static int Right() { trace += "R"; return 5; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int result = checked(Left() + Right()) * 3;
        Check(result == 21, "checked-grouping");
        Check(trace == "LR", "checked-contained-expression-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
