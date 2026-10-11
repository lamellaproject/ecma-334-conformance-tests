/*
Rules: E12-2-1-value-type; E12-2-1-classifications
Authority: ECMA-334 7th ed 12.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Choose(31)
Into: Choose(31L)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Choose(int value) { return 1; }
    static int Choose(long value) { return 2; }
    static void Main()
    {
        int result = Choose(31);
        Check(result == 1, "value-associated-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
