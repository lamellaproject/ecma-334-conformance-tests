/*
Rules: E12-8-7-1-bool-form; E12-8-7-1-predefined-member-form; E12-8-7-1-absent-type-arity
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: bool.TrueString
Into: bool.FalseString
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string result = bool.TrueString;
        Check(result == "True", "bool-keyword-is-member-receiver");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
