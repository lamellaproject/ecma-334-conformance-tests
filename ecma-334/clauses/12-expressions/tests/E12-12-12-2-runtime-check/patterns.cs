/*
Rules: E12-12-12-2-runtime-check; E12-12-12-pattern-form; E12-12-12-2-match-true; E12-12-12-2-no-match-false
Authority: ECMA-334 7th ed 12.12.12.2
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: source is int number
Into: source is long number
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object source = 3;
        bool match = source is int number && number == 3; Check(match, "runtime-declaration-pattern-value");
        source = "text"; Check(!(source is int), "runtime-nonmatch");
        source = 7; Check(source is 7, "constant-pattern-match");
        source = null; Check(source is null, "null-pattern-match");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
