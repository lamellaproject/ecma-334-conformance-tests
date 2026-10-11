/*
Rules: E12-8-18-predefined-constant-int; E12-8-18-predefined-int-type; E12-8-18-variable-size; E12-8-18-syntax; E12-8-18-sbyte-size; E12-8-18-byte-size; E12-8-18-short-size; E12-8-18-ushort-size; E12-8-18-int-size; E12-8-18-uint-size; E12-8-18-long-size; E12-8-18-ulong-size; E12-8-18-char-size; E12-8-18-float-size; E12-8-18-double-size; E12-8-18-bool-size; E12-8-18-decimal-size
Authority: ECMA-334 7th ed 12.8.18
Version: 7.3
Expected: run
Stdout: OK 14
Mutate: const int SByte = sizeof(sbyte);
Into: const int SByte = sizeof(short);
*/
using System;
class Program
{
    const int SByte = sizeof(sbyte);
    const int Byte = sizeof(byte), Short = sizeof(short), UShort = sizeof(ushort);
    const int Int = sizeof(int), UInt = sizeof(uint), Long = sizeof(long), ULong = sizeof(ulong);
    const int Char = sizeof(char), Float = sizeof(float), Double = sizeof(double), Bool = sizeof(bool);
    const int Decimal = sizeof(decimal);
    static int Choose(int value) { return 1; }
    static int Choose(uint value) { return 2; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(SByte == 1, "sizeof-sbyte");
        Check(Byte == 1, "sizeof-byte");
        Check(Short == 2, "sizeof-short");
        Check(UShort == 2, "sizeof-ushort");
        Check(Int == 4, "sizeof-int");
        Check(UInt == 4, "sizeof-uint");
        Check(Long == 8, "sizeof-long");
        Check(ULong == 8, "sizeof-ulong");
        Check(Char == 2, "sizeof-char");
        Check(Float == 4, "sizeof-float");
        Check(Double == 8, "sizeof-double");
        Check(Bool == 1, "sizeof-bool");
        Check(Decimal == 16, "sizeof-decimal");
        Check(Choose(sizeof(long)) == 1, "sizeof-result-type-int");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
