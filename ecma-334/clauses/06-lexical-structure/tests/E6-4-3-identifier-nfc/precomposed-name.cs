/*
Rules: E6-4-3-identifier-nfc
Authority: ECMA-334 7th ed 6.4.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int \u00E9tude = 37;
Into: int \u00E8tude = 37;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int \u00E9tude = 37;
        Check(\U000000E9tude == 37, "nfc-precomposed-identifier");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
