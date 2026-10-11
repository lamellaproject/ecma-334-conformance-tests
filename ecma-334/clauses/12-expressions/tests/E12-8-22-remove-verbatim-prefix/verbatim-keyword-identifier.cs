/*
Rules: E12-8-22-remove-verbatim-prefix
Authority: ECMA-334 7th ed 12.8.22
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: nameof(@while)
Into: nameof(other)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int @while = 7, other = 19;
        Check(nameof(@while) == "while", "verbatim-prefix-removed");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
