/*
Rules: E12-4-1-ternary-notation; E12-4-1-ternary-operator; E12-4-1-ternary-arity
Authority: ECMA-334 7th ed 12.4.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: flag ? 19 : 23
Into: flag ? 23 : 19
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Select(bool flag) { return flag ? 19 : 23; }
    static void Main()
    {
        Check(Select(true) == 19, "conditional-true-branch");
        Check(Select(false) == 23, "conditional-false-branch");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
