/*
Rules: E12-19-1-explicit-parentheses; E12-19-1-anonymous-method-form
Authority: ECMA-334 7th ed 12.19.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: delegate() { return 31; }
Into: delegate(int value) { return 31; }
*/
using System;
delegate int Result();
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Result function = delegate() { return 31; };
        Check(function() == 31, "explicit-signature-allows-empty-parameter-list");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
