/*
Rules: E12-11-explicit-signedness
Authority: ECMA-334 7th ed 12.11
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: unchecked((uint)s) >> count
Into: unchecked((uint)(s >> count))
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int s = -8, count = 2; uint u = 0xFFFFFFF8U;
        long l = -8; ulong ul = 0xFFFFFFFFFFFFFFF8UL;
        Check(unchecked((uint)s) >> count == 0x3FFFFFFEU, "signed-to-unsigned-logical");
        Check(unchecked((int)u) >> count == -2, "unsigned-to-signed-arithmetic");
        Check(unchecked((ulong)l) >> count == 0x3FFFFFFFFFFFFFFEUL, "long-to-unsigned-logical");
        Check(unchecked((long)ul) >> count == -2L, "ulong-to-signed-arithmetic");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
