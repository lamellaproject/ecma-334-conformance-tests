/*
Rules: E8-3-6-ulong-range; E8-3-6-ulong-format; E8-3-5-alias-ulong; E8-3-5-simple-system-aliases; E8-3-5-simple-type-members; E8-3-1-integral-form-ulong; E8-3-1-numeric-form-integral; E8-3-1-simple-form-numeric; E8-3-1-struct-form-simple; E8-3-1-simple-types-keywords; E8-3-6-integral-types; E8-3-3-simple-default-bits; E8-8-unmanaged-simple-types; E8-8-unmanaged-form-value; E8-3-3-integral-default
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
        ulong low = 0UL; ulong high = 18446744073709551615UL; ulong empty = new ulong();
        System.UInt64 alias = 36UL; ulong same = alias;
        byte* zeros = (byte*)&empty; bool allZeros = true;
        for (int i = 0; i < sizeof(ulong); i++) if (zeros[i] != 0) allZeros = false;
        ulong* address = &same;
        Check(sizeof(ulong) == 8, "ulong-storage-width");
        Check(low == 0UL && high == 18446744073709551615UL, "ulong-inclusive-endpoints");
        Check(same == 36UL, "ulong-keyword-alias");
        Check(empty == (ulong)0, "ulong-default-zero");
        Check(empty.CompareTo(same) < 0, "ulong-aliased-members");
        Check(allZeros, "ulong-default-bits");
        Check(*address == same, "ulong-unmanaged-address");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
