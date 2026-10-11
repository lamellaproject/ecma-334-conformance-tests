/*
Rules: E12-9-6-predefined-increment; E12-9-6-increment-value; E12-9-6-result-type; E12-9-6-form-increment; E12-9-1-form-increment
Authority: ECMA-334 7th ed 12.9.6
Version: 7.3
Expected: run
Stdout: OK 13
Mutate: ++sb
Into: --sb
*/
using System;
enum Count : byte { Start = 9 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        sbyte sb = -2; byte b = 2; short s = -5; ushort us = 5; int i = -11; uint u = 11;
        long l = -17; ulong ul = 17; char c = 'k'; float f = 1.5f; double d = 2.25; decimal m = 3.125m;
        Count e = Count.Start;
        sbyte rsb = ++sb; byte rb = ++b; short rs = ++s; ushort rus = ++us; int ri = ++i; uint ru = ++u;
        long rl = ++l; ulong rul = ++ul; char rc = ++c; float rf = ++f; double rd = ++d; decimal rm = ++m;
        Count re = ++e;
        Check(rsb == -1 && sb == -1, "sbyte"); Check(rb == 3 && b == 3, "byte");
        Check(rs == -4 && s == -4, "short"); Check(rus == 6 && us == 6, "ushort");
        Check(ri == -10 && i == -10, "int"); Check(ru == 12 && u == 12, "uint");
        Check(rl == -16 && l == -16, "long"); Check(rul == 18 && ul == 18, "ulong");
        Check(rc == 'l' && c == 'l', "char"); Check(rf == 2.5f && f == 2.5f, "float");
        Check(rd == 3.25 && d == 3.25, "double"); Check(rm == 4.125m && m == 4.125m, "decimal");
        Check((byte)re == 10 && (byte)e == 10, "enum");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
