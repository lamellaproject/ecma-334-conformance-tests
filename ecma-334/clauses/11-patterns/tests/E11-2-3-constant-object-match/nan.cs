/*
Rules: E11-2-3-constant-object-match
Authority: ECMA-334 7th ed 11.2.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: source is double.NaN
Into: source is 0.0
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool Matches(double source) { return source is double.NaN; }
    static void Main()
    {
        Check(Matches(double.NaN), "nan-equals-nan");
        Check(!Matches(1.0), "finite-not-nan");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
