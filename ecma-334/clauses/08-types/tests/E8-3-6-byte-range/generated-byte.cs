/*
Rules: E8-3-6-byte-range; E8-3-6-byte-format; E8-3-5-alias-byte; E8-3-5-simple-system-aliases; E8-3-5-simple-type-members; E8-3-1-integral-form-byte; E8-3-1-numeric-form-integral; E8-3-1-simple-form-numeric; E8-3-1-struct-form-simple; E8-3-1-simple-types-keywords; E8-3-6-integral-types; E8-3-3-simple-default-bits; E8-8-unmanaged-simple-types; E8-8-unmanaged-form-value; E8-3-3-integral-default
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
        byte low = 0; byte high = 255; byte empty = new byte();
        System.Byte alias = 36; byte same = alias;
        byte* zeros = (byte*)&empty; bool allZeros = true;
        for (int i = 0; i < sizeof(byte); i++) if (zeros[i] != 0) allZeros = false;
        byte* address = &same;
        Check(sizeof(byte) == 1, "byte-storage-width");
        Check(low == 0 && high == 255, "byte-inclusive-endpoints");
        Check(same == 36, "byte-keyword-alias");
        Check(empty == (byte)0, "byte-default-zero");
        Check(empty.CompareTo(same) < 0, "byte-aliased-members");
        Check(allZeros, "byte-default-bits");
        Check(*address == same, "byte-unmanaged-address");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
