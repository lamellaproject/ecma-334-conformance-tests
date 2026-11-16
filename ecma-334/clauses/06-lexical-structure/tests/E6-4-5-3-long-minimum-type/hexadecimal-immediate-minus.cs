/*
Rules: E6-4-5-3-long-minimum-type; E6-4-5-3-long-minimum-value
Authority: ECMA-334 7th ed 6.4.5.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: const long minimum = -0X8000000000000000;
Into: const long minimum = -0X8000000000000001;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Kind(long value) { return 1; }
    static int Kind(ulong value) { return 2; }
    static void Main()
    {
        const long minimum = -0X8000000000000000;
        Check(minimum == -9223372036854775807L - 1L, "hexadecimal-minimum-value");
        Check(Kind(-0X8000000000000000) == 1, "unsuffixed-minimum-type");
        Check(Kind(-0x8000000000000000L) == 1, "uppercase-suffix-minimum-type");
        Check(Kind(-0x8000000000000000l) == 1, "lowercase-suffix-minimum-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
