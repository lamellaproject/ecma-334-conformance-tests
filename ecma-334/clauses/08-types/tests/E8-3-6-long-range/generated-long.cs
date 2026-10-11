/*
Rules: E8-3-6-long-range; E8-3-6-long-format; E8-3-5-alias-long; E8-3-5-simple-system-aliases; E8-3-5-simple-type-members; E8-3-1-integral-form-long; E8-3-1-numeric-form-integral; E8-3-1-simple-form-numeric; E8-3-1-struct-form-simple; E8-3-1-simple-types-keywords; E8-3-6-integral-types; E8-3-3-simple-default-bits; E8-8-unmanaged-simple-types; E8-8-unmanaged-form-value; E8-3-3-integral-default; E8-3-6-signed-twos-complement
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
        long low = -9223372036854775808L; long high = 9223372036854775807L; long empty = new long();
        System.Int64 alias = 36L; long same = alias;
        byte* zeros = (byte*)&empty; bool allZeros = true;
        for (int i = 0; i < sizeof(long); i++) if (zeros[i] != 0) allZeros = false;
        long* address = &same;
        long negative = -1; byte* bytes = (byte*)&negative; bool allOnes = true;
        for (int i = 0; i < sizeof(long); i++) if (bytes[i] != 255) allOnes = false;
        Check(sizeof(long) == 8, "long-storage-width");
        Check(low == -9223372036854775808L && high == 9223372036854775807L, "long-inclusive-endpoints");
        Check(same == 36L, "long-keyword-alias");
        Check(empty == (long)0, "long-default-zero");
        Check(empty.CompareTo(same) < 0, "long-aliased-members");
        Check(allZeros, "long-default-bits");
        Check(*address == same, "long-unmanaged-address");
        Check(allOnes, "long-twos-complement-negative-one");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
