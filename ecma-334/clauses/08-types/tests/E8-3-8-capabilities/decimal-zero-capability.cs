/*
Rules: E8-3-8-capabilities
Authority: ECMA-334 7th ed 8.3.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: new decimal(0, 0, 0, true, 0)
Into: new decimal(1, 0, 0, true, 0)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        decimal zero = new decimal(0, 0, 0, true, 0); int[] bits = decimal.GetBits(zero);
        // A format may retain the negative sign of zero or normalize it; neither is required.
        bool allowedSign = bits[3] == 0 || bits[3] == unchecked((int)0x80000000);
        Check(zero == 0m && allowedSign, "optional-signed-decimal-zero");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
