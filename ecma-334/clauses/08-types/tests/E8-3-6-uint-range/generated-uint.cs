/*
Rules: E8-3-6-uint-range; E8-3-6-uint-format; E8-3-5-alias-uint; E8-3-5-simple-system-aliases; E8-3-5-simple-type-members; E8-3-1-integral-form-uint; E8-3-1-numeric-form-integral; E8-3-1-simple-form-numeric; E8-3-1-struct-form-simple; E8-3-1-simple-types-keywords; E8-3-6-integral-types; E8-3-3-simple-default-bits; E8-8-unmanaged-simple-types; E8-8-unmanaged-form-value; E8-3-3-integral-default
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
        uint low = 0U; uint high = 4294967295U; uint empty = new uint();
        System.UInt32 alias = 36U; uint same = alias;
        byte* zeros = (byte*)&empty; bool allZeros = true;
        for (int i = 0; i < sizeof(uint); i++) if (zeros[i] != 0) allZeros = false;
        uint* address = &same;
        Check(sizeof(uint) == 4, "uint-storage-width");
        Check(low == 0U && high == 4294967295U, "uint-inclusive-endpoints");
        Check(same == 36U, "uint-keyword-alias");
        Check(empty == (uint)0, "uint-default-zero");
        Check(empty.CompareTo(same) < 0, "uint-aliased-members");
        Check(allZeros, "uint-default-bits");
        Check(*address == same, "uint-unmanaged-address");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
