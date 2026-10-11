/*
Rules: E12-11-bit-shift-operators; E12-11-form-additive; E12-11-form-left; E12-11-form-right
Authority: ECMA-334 7th ed 12.11
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: x << count + one
Into: (x << count) + one
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int x = 3, count = 2, one = 1;
        Check(x << count + one == 24, "additive-count");
        Check(x + one << count == 16, "additive-value");
        Check(x << count >> one == 6, "shift-chain-left-grouping");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
