/*
Rules: E8-3-3-decimal-default
Authority: ECMA-334 7th ed 8.3.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: decimal value = new decimal();
Into: decimal value = new decimal(0, 0, 0, false, 3);
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        decimal value = new decimal(); int[] bits = decimal.GetBits(value);
        Check(value == 0m && bits[0] == 0 && bits[1] == 0 && bits[2] == 0 && bits[3] == 0, "decimal-default-zero-scale-zero");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
