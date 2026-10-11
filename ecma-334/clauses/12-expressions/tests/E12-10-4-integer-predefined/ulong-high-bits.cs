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
    static ulong Remainder(ulong left, ulong right) { return left % right; }
    static void Main()
    {
        Check(Remainder(18446744073709551615UL, 5UL) == 0UL, "high-dividend");
        Check(Remainder(3UL, 18446744073709551615UL) == 3UL, "high-divisor");
        Check(Remainder(9223372036854775808UL, 3UL) == 2UL, "sign-bit-dividend");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
