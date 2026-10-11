/*
Rules: E12-8-20-predefined-value-constant
Authority: ECMA-334 7th ed 12.8.20
Version: 7.3
Expected: run
Stdout: OK 13
Mutate: const int integer = default(int);
Into: const int integer = Read();
*/
using System;
class Program
{
    static int Read() { return 0; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        const sbyte signedByte = default(sbyte);
        const byte unsignedByte = default(byte);
        const short signedWord = default(short);
        const ushort unsignedWord = default(ushort);
        const int integer = default(int);
        const uint unsignedInteger = default(uint);
        const long wide = default(long);
        const ulong unsignedWide = default(ulong);
        const char character = default(char);
        const float real = default(float);
        const double precise = default(double);
        const decimal money = default(decimal);
        const bool truth = default(bool);
        Check(signedByte == 0, "default-sbyte-constant");
        Check(unsignedByte == 0, "default-byte-constant");
        Check(signedWord == 0, "default-short-constant");
        Check(unsignedWord == 0, "default-ushort-constant");
        Check(integer == 0, "default-int-constant");
        Check(unsignedInteger == 0, "default-uint-constant");
        Check(wide == 0, "default-long-constant");
        Check(unsignedWide == 0, "default-ulong-constant");
        Check(character == '\0', "default-char-constant");
        Check(BitConverter.SingleToInt32Bits(real) == 0, "default-float-positive-zero-bits");
        Check(BitConverter.DoubleToInt64Bits(precise) == 0, "default-double-positive-zero-bits");
        int[] bits = decimal.GetBits(money);
        Check(bits.Length == 4 && bits[0] == 0 && bits[1] == 0 && bits[2] == 0 && bits[3] == 0, "default-decimal-zero-bits");
        Check(!truth, "default-bool-constant");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
