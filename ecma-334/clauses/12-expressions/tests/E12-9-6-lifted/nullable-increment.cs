/*
Rules: E12-9-6-lifted
Authority: ECMA-334 7th ed 12.9.6
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: ++value
Into: --value
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int? value = 4; int? missing = null;
        Check(++value == 5 && value == 5, "increment-value"); Check(--value == 4 && value == 4, "decrement-value");
        Check(++missing == null && --missing == null && missing == null, "null-stays-null");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
