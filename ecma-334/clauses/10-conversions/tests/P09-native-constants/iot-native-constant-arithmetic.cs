/*
Rules: P09-native-constants
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 10
Mutate: const nint arithmetic = (nint)19 * 7 - 3;
Into: const nint arithmetic = (nint)19 * 8 - 3;
*/
using System;
class Program
{
    static int checks, failures;
    const nint arithmetic = (nint)19 * 7 - 3;
    const nint unary = -(+(nint)17);
    const nuint unsignedArithmetic = ((nuint)31 / 4) * 5 + 2;
    const nint remainder = (nint)(-31) % 4;
    const nint bits = ((nint)13 | 2) ^ 1;
    const nuint mask = (nuint)4294967295U & 7;
    const nint shifted = (nint)3 << 4;
    const nuint unsignedShifted = (nuint)2147483651U >> 1;
    const bool comparison = (nint)13 < (nint)19;
    const nint boundary = (nint)(-2147483647 - 1);
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Check(arithmetic == 130, "native-constant-arithmetic");
        Check(unary == -17, "native-constant-unary");
        Check(unsignedArithmetic == 37, "native-constant-unsigned-arithmetic");
        Check(remainder == -3, "native-constant-remainder-sign");
        Check(bits == 14, "native-constant-bitwise");
        Check(mask == 7, "native-constant-unsigned-mask");
        Check(shifted == 48, "native-constant-left-shift");
        Check(unsignedShifted == 1073741825U, "native-constant-unsigned-right-shift");
        Check(comparison, "native-constant-comparison");
        Check(boundary == -2147483648L, "native-constant-signed-boundary");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
