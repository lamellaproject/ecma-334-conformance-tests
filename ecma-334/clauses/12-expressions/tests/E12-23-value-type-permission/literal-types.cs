/*
Rules: E12-23-value-type-permission; E12-23-literals; E12-23-form
Authority: ECMA-334 7th ed 12.23
Version: 7.3
Expected: run
Stdout: OK 14
Mutate: const long signedLong = -5000000000L;
Into: const long signedLong = -5000000001L;
*/
using System;
enum Tone : byte { Signal = 9 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe int Bits(float value) { return *(int*)&value; }
    static unsafe long Bits(double value) { return *(long*)&value; }
    static void Main()
    {
        const sbyte signedByte = -91;
        const byte unsignedByte = 219;
        const short signedShort = -28000;
        const ushort unsignedShort = 61000;
        const int signedInt = 721;
        const uint unsignedInt = 4000000000U;
        const long signedLong = -5000000000L;
        const ulong unsignedLong = 10000000000UL;
        const char character = 'k';
        const float single = 1.5F;
        const double real = 2.5;
        const decimal precise = 3.75M;
        const bool flag = true;
        const Tone tone = Tone.Signal;
        Check(signedByte == -91, "constant-sbyte");
        Check(unsignedByte == 219, "constant-byte");
        Check(signedShort == -28000, "constant-short");
        Check(unsignedShort == 61000, "constant-ushort");
        Check(signedInt == 721, "constant-int");
        Check(unsignedInt == 4000000000U, "constant-uint");
        Check(signedLong == -5000000000L, "constant-long");
        Check(unsignedLong == 10000000000UL, "constant-ulong");
        Check(character == (char)107, "constant-char");
        Check(Bits(single) == 0x3fc00000, "constant-float-bits");
        Check(Bits(real) == 0x4004000000000000L, "constant-double-bits");
        Check(precise == 3.75M, "constant-decimal");
        Check(flag, "constant-bool");
        Check((byte)tone == 9, "constant-enum");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
