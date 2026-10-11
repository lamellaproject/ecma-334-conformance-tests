/*
Rules: E7-3-local-space-name-sources
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: is int matched
Into: is int renamed
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object source = 17;
        if (source is int matched) Check(matched == 17, "pattern-name-introduced");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
