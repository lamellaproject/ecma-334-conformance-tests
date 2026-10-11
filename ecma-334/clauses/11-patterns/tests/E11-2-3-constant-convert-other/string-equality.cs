/*
Rules: E11-2-3-constant-convert-other; E11-2-3-constant-object-match
Authority: ECMA-334 7th ed 11.2.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: source is "harbor"
Into: source is "canal"
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool Matches(string source) { return source is "harbor"; }
    static void Main()
    {
        string assembled = new string(new char[] { 'h', 'a', 'r', 'b', 'o', 'r' });
        Check(Matches(assembled), "equal-content");
        Check(!Matches("canal"), "different-content");
        Check(!Matches(null), "string-null");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
