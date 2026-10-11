/*
Rules: E12-14-1-or-short-circuit; E12-14-1-or-correspondence; E12-14-1-boolean-dispatch; E12-14-2-boolean-operands; E12-14-2-or-true-left; E12-14-2-or-false-left
Authority: ECMA-334 7th ed 12.14
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: A(true, "L") || A(false, "R")
Into: A(true, "L") | A(false, "R")
*/
using System;
class Program
{
    static string trace = "";
    static bool A(bool value, string id) { trace += id; return value; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool a = A(true, "L") || A(false, "R"); Check(a && trace == "L", "true-left-skips-right");
        trace = ""; bool b = A(false, "L") || A(false, "R"); Check(!b && trace == "LR", "false-left-right-false");
        trace = ""; bool c = A(false, "L") || A(true, "R"); Check(c && trace == "LR", "false-left-right-true");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
