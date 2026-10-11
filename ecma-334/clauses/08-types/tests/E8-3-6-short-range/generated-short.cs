/*
Rules: E8-3-6-short-range; E8-3-6-short-format; E8-3-5-alias-short; E8-3-5-simple-system-aliases; E8-3-5-simple-type-members; E8-3-1-integral-form-short; E8-3-1-numeric-form-integral; E8-3-1-simple-form-numeric; E8-3-1-struct-form-simple; E8-3-1-simple-types-keywords; E8-3-6-integral-types; E8-3-3-simple-default-bits; E8-8-unmanaged-simple-types; E8-8-unmanaged-form-value; E8-3-3-integral-default; E8-3-6-signed-twos-complement
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
        short low = -32768; short high = 32767; short empty = new short();
        System.Int16 alias = 36; short same = alias;
        byte* zeros = (byte*)&empty; bool allZeros = true;
        for (int i = 0; i < sizeof(short); i++) if (zeros[i] != 0) allZeros = false;
        short* address = &same;
        short negative = -1; byte* bytes = (byte*)&negative; bool allOnes = true;
        for (int i = 0; i < sizeof(short); i++) if (bytes[i] != 255) allOnes = false;
        Check(sizeof(short) == 2, "short-storage-width");
        Check(low == -32768 && high == 32767, "short-inclusive-endpoints");
        Check(same == 36, "short-keyword-alias");
        Check(empty == (short)0, "short-default-zero");
        Check(empty.CompareTo(same) < 0, "short-aliased-members");
        Check(allZeros, "short-default-bits");
        Check(*address == same, "short-unmanaged-address");
        Check(allOnes, "short-twos-complement-negative-one");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
