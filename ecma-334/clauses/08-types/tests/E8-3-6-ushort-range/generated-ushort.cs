/*
Rules: E8-3-6-ushort-range; E8-3-6-ushort-format; E8-3-5-alias-ushort; E8-3-5-simple-system-aliases; E8-3-5-simple-type-members; E8-3-1-integral-form-ushort; E8-3-1-numeric-form-integral; E8-3-1-simple-form-numeric; E8-3-1-struct-form-simple; E8-3-1-simple-types-keywords; E8-3-6-integral-types; E8-3-3-simple-default-bits; E8-8-unmanaged-simple-types; E8-8-unmanaged-form-value; E8-3-3-integral-default
Authority: ECMA-334 7th ed 8.3.6
Version: 7.3
Expected: run
Stdout: OK 7
Generated: clauses/08-types/generators/numeric-matrix.py
*/
using System;
unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        ushort low = 0; ushort high = 65535; ushort empty = new ushort();
        System.UInt16 alias = 36; ushort same = alias;
        byte* zeros = (byte*)&empty; bool allZeros = true;
        for (int i = 0; i < sizeof(ushort); i++) if (zeros[i] != 0) allZeros = false;
        ushort* address = &same;
        Check(sizeof(ushort) == 2, "ushort-storage-width");
        Check(low == 0 && high == 65535, "ushort-inclusive-endpoints");
        Check(same == 36, "ushort-keyword-alias");
        Check(empty == (ushort)0, "ushort-default-zero");
        Check(empty.CompareTo(same) < 0, "ushort-aliased-members");
        Check(allZeros, "ushort-default-bits");
        Check(*address == same, "ushort-unmanaged-address");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
