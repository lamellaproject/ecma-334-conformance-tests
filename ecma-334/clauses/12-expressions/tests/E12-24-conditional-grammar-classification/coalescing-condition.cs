/*
Rules: E12-24-conditional-grammar-classification; E12-24-conditional-same-rules; E12-24-true-runtime-invocation
Authority: ECMA-334 7th ed 12.24
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: ?? new Flag(true)
Into: ?? new Flag(false)
*/
using System;
class Flag
{
    bool value;
    public Flag(bool value) { this.value = value; }
    public static bool operator true(Flag flag) { Program.trace += "T"; return flag.value; }
    public static bool operator false(Flag flag) { Program.trace += "F"; return !flag.value; }
}
class Program
{
    public static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Flag missing = null;
        int result = missing ?? new Flag(true) ? 7 : 9;
        Check(result == 7, "coalescing-is-whole-conditional-control");
        Check(trace == "T", "coalesced-value-uses-true-operator");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
