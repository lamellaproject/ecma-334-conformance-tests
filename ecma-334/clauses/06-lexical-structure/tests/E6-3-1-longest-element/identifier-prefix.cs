/*
Rules: E6-3-1-longest-element
Authority: ECMA-334 7th ed 6.3.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: longer = 13
Into: long = 13
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int longer = 13;
        int longish = 6;
        Check(longer == 13, "keyword-prefix-is-identifier");
        Check(longish == 6, "second-keyword-prefix");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
