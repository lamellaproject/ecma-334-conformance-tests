/*
Rules: E12-8-15-predefined-increment-types; E12-8-15-predefined-decrement-types; E12-8-15-increment-value; E12-8-15-decrement-value; E12-8-15-result-type
Authority: ECMA-334 7th ed 12.8.15
Version: 7.3
Expected: run
Stdout: OK 16
Mutate: int sa = a++;
Into: int sa = a--;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int a = 4; int sa = a++;
        Check(sa == 4, "int-increment-old-value"); Check(a == 5, "int-increment-new-value");
        sa = a--;
        Check(sa == 5, "int-decrement-old-value"); Check(a == 4, "int-decrement-new-value");
        uint b = 4; uint sb = b++;
        Check(sb == 4, "uint-increment-old-value"); Check(b == 5, "uint-increment-new-value");
        sb = b--;
        Check(sb == 5, "uint-decrement-old-value"); Check(b == 4, "uint-decrement-new-value");
        long c = 4; long sc = c++;
        Check(sc == 4, "long-increment-old-value"); Check(c == 5, "long-increment-new-value");
        sc = c--;
        Check(sc == 5, "long-decrement-old-value"); Check(c == 4, "long-decrement-new-value");
        ulong d = 4; ulong sd = d++;
        Check(sd == 4, "ulong-increment-old-value"); Check(d == 5, "ulong-increment-new-value");
        sd = d--;
        Check(sd == 5, "ulong-decrement-old-value"); Check(d == 4, "ulong-decrement-new-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
