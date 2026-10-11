/*
Rules: E8-3-6-int-range; E8-3-6-int-format; E8-3-5-alias-int; E8-3-5-simple-system-aliases; E8-3-5-simple-type-members; E8-3-1-integral-form-int; E8-3-1-numeric-form-integral; E8-3-1-simple-form-numeric; E8-3-1-struct-form-simple; E8-3-1-simple-types-keywords; E8-3-6-integral-types; E8-3-3-simple-default-bits; E8-8-unmanaged-simple-types; E8-8-unmanaged-form-value; E8-3-3-integral-default; E8-3-6-signed-twos-complement
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
        int low = -2147483648; int high = 2147483647; int empty = new int();
        System.Int32 alias = 36; int same = alias;
        byte* zeros = (byte*)&empty; bool allZeros = true;
        for (int i = 0; i < sizeof(int); i++) if (zeros[i] != 0) allZeros = false;
        int* address = &same;
        int negative = -1; byte* bytes = (byte*)&negative; bool allOnes = true;
        for (int i = 0; i < sizeof(int); i++) if (bytes[i] != 255) allOnes = false;
        Check(sizeof(int) == 4, "int-storage-width");
        Check(low == -2147483648 && high == 2147483647, "int-inclusive-endpoints");
        Check(same == 36, "int-keyword-alias");
        Check(empty == (int)0, "int-default-zero");
        Check(empty.CompareTo(same) < 0, "int-aliased-members");
        Check(allZeros, "int-default-bits");
        Check(*address == same, "int-unmanaged-address");
        Check(allOnes, "int-twos-complement-negative-one");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
