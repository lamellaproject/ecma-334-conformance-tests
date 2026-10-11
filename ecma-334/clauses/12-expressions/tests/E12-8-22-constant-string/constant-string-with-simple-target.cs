/*
Rules: E12-8-22-constant-string; E12-8-22-string-type; E12-8-22-syntax; E12-8-22-simple-target-form; E12-8-22-nameof-fallback
Authority: ECMA-334 7th ed 12.8.22
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: nameof(count)
Into: nameof(other)
*/
using System;
class Program
{
    static int Choose(string value) { return 1; }
    static int Choose(object value) { return 2; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int count = 7, other = 19;
        const string name = nameof(count);
        Check(name == "count", "nameof-constant-value");
        Check(Choose(name) == 1, "nameof-string-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
