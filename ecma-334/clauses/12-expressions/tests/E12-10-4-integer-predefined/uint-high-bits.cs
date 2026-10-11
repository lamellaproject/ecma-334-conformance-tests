/*
Rules: E12-10-4-integer-predefined; E12-10-4-remainder; E12-10-4-integer-value
Authority: ECMA-334 7th ed 12.10.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: return left % right;
Into: return left / right;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static uint Remainder(uint left, uint right) { return left % right; }
    static void Main()
    {
        Check(Remainder(4294967295U, 5U) == 0U, "high-dividend");
        Check(Remainder(3U, 4294967295U) == 3U, "high-divisor");
        Check(Remainder(2147483648U, 3U) == 2U, "sign-bit-dividend");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
