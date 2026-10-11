/*
Rules: E12-14-1-and-short-circuit; E12-14-1-and-correspondence; E12-14-1-boolean-dispatch; E12-14-2-boolean-operands; E12-14-2-and-false-left; E12-14-2-and-true-left
Authority: ECMA-334 7th ed 12.14
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: A(false, "L") && A(true, "R")
Into: A(false, "L") & A(true, "R")
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
        bool a = A(false, "L") && A(true, "R"); Check(!a && trace == "L", "false-left-skips-right");
        trace = ""; bool b = A(true, "L") && A(false, "R"); Check(!b && trace == "LR", "true-left-right-false");
        trace = ""; bool c = A(true, "L") && A(true, "R"); Check(c && trace == "LR", "true-left-right-true");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
