/*
Rules: E8-3-6-sbyte-range; E8-3-6-sbyte-format; E8-3-5-alias-sbyte; E8-3-5-simple-system-aliases; E8-3-5-simple-type-members; E8-3-1-integral-form-sbyte; E8-3-1-numeric-form-integral; E8-3-1-simple-form-numeric; E8-3-1-struct-form-simple; E8-3-1-simple-types-keywords; E8-3-6-integral-types; E8-3-3-simple-default-bits; E8-8-unmanaged-simple-types; E8-8-unmanaged-form-value; E8-3-3-integral-default; E8-3-6-signed-twos-complement
Authority: ECMA-334 7th ed 8.3.6
Version: 7.3
Expected: run
Stdout: OK 8
Generated: clauses/08-types/generators/numeric-matrix.py
*/
using System;
unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        sbyte low = -128; sbyte high = 127; sbyte empty = new sbyte();
        System.SByte alias = 36; sbyte same = alias;
        byte* zeros = (byte*)&empty; bool allZeros = true;
        for (int i = 0; i < sizeof(sbyte); i++) if (zeros[i] != 0) allZeros = false;
        sbyte* address = &same;
        sbyte negative = -1; byte* bytes = (byte*)&negative; bool allOnes = true;
        for (int i = 0; i < sizeof(sbyte); i++) if (bytes[i] != 255) allOnes = false;
        Check(sizeof(sbyte) == 1, "sbyte-storage-width");
        Check(low == -128 && high == 127, "sbyte-inclusive-endpoints");
        Check(same == 36, "sbyte-keyword-alias");
        Check(empty == (sbyte)0, "sbyte-default-zero");
        Check(empty.CompareTo(same) < 0, "sbyte-aliased-members");
        Check(allZeros, "sbyte-default-bits");
        Check(*address == same, "sbyte-unmanaged-address");
        Check(allOnes, "sbyte-twos-complement-negative-one");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
