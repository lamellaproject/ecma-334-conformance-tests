/*
Rules: E12-13-4-and-result; E12-13-4-or-result; E12-13-4-xor-result
Authority: ECMA-334 7th ed 12.13.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Take(false, "L") & Take(true, "R")
Into: Take(false, "L") && Take(true, "R")
*/
using System;
class Program
{
    static string trace = "";
    static bool Take(bool value, string id) { trace += id; return value; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool a = Take(false, "L") & Take(true, "R"); Check(!a && trace == "LR", "and-eager");
        trace = ""; bool b = Take(true, "L") | Take(false, "R"); Check(b && trace == "LR", "or-eager");
        trace = ""; bool c = Take(true, "L") ^ Take(true, "R"); Check(!c && trace == "LR", "xor-eager");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
