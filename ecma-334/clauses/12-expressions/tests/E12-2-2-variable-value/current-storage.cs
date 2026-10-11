/*
Rules: E12-2-2-variable-value
Authority: ECMA-334 7th ed 12.2.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: value = 29;
Into: value = 18;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = 18; value = 29;
        Check(value == 29, "current-variable-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
