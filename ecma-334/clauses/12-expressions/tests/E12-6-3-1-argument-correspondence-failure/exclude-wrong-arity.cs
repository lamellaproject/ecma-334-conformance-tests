/*
Rules: E12-6-3-1-argument-correspondence-failure; E12-6-3-1-missing-required-failure
Authority: ECMA-334 7th ed 12.6.3.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Select(4, extra: 6)
Into: Select(4)
*/
using System;
class Program
{
    static int checks, failures;
    static int Select<T>(T item) { return 1; }
    static int Select<T>(T item, int extra) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Select(4, extra: 6) == 2, "unmatched-named-argument-excludes-short-candidate");
        Check(Select(9) == 1, "missing-required-argument-excludes-long-candidate");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
