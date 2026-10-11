/*
Rules: E12-8-15-predefined-increment-types; E12-8-15-predefined-decrement-types; E12-8-15-increment-value; E12-8-15-decrement-value; E12-8-15-result-type; E12-8-15-increment-form; E12-8-15-decrement-form
Authority: ECMA-334 7th ed 12.8.15
Version: 7.3
Expected: run
Stdout: OK 16
Mutate: sbyte sa = a++;
Into: sbyte sa = a--;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        sbyte a = 4; sbyte sa = a++;
        Check(sa == 4, "sbyte-increment-old-value"); Check(a == 5, "sbyte-increment-new-value");
        sa = a--;
        Check(sa == 5, "sbyte-decrement-old-value"); Check(a == 4, "sbyte-decrement-new-value");
        byte b = 4; byte sb = b++;
        Check(sb == 4, "byte-increment-old-value"); Check(b == 5, "byte-increment-new-value");
        sb = b--;
        Check(sb == 5, "byte-decrement-old-value"); Check(b == 4, "byte-decrement-new-value");
        short c = 4; short sc = c++;
        Check(sc == 4, "short-increment-old-value"); Check(c == 5, "short-increment-new-value");
        sc = c--;
        Check(sc == 5, "short-decrement-old-value"); Check(c == 4, "short-decrement-new-value");
        ushort d = 4; ushort sd = d++;
        Check(sd == 4, "ushort-increment-old-value"); Check(d == 5, "ushort-increment-new-value");
        sd = d--;
        Check(sd == 5, "ushort-decrement-old-value"); Check(d == 4, "ushort-decrement-new-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
