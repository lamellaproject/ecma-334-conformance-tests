/*
Rules: E12-9-6-predefined-decrement; E12-9-6-decrement-value; E12-9-6-result-type; E12-9-6-form-decrement; E12-9-1-form-decrement
Authority: ECMA-334 7th ed 12.9.6
Version: 7.3
Expected: run
Stdout: OK 13
Mutate: --sb
Into: ++sb
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
        sbyte rsb = --sb; byte rb = --b; short rs = --s; ushort rus = --us; int ri = --i; uint ru = --u;
        long rl = --l; ulong rul = --ul; char rc = --c; float rf = --f; double rd = --d; decimal rm = --m;
        Count re = --e;
        Check(rsb == -3 && sb == -3, "sbyte"); Check(rb == 1 && b == 1, "byte");
        Check(rs == -6 && s == -6, "short"); Check(rus == 4 && us == 4, "ushort");
        Check(ri == -12 && i == -12, "int"); Check(ru == 10 && u == 10, "uint");
        Check(rl == -18 && l == -18, "long"); Check(rul == 16 && ul == 16, "ulong");
        Check(rc == 'j' && c == 'j', "char"); Check(rf == 0.5f && f == 0.5f, "float");
        Check(rd == 1.25 && d == 1.25, "double"); Check(rm == 2.125m && m == 2.125m, "decimal");
        Check((byte)re == 8 && (byte)e == 8, "enum");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
