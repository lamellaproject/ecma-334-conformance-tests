/*
Rules: E11-2-2-compatible-open-pattern
Authority: ECMA-334 7th ed 11.2.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: input is T value
Into: input is long value
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool Find<T>(object input) { return input is T value; }
    static void Main()
    {
        Check(Find<int>(29), "open-pattern-match");
        Check(!Find<string>(29), "open-pattern-no-match");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
