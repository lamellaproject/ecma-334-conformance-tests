/*
Rules: P09-native-shift-mask; P09-native-right-shift-sign
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 7
Mutate: value << count
Into: value << (count & 31)
*/
using System;
class Program
{
    static int checks, failures;
    static nint Shift(nint value, int count) { return value << count; }
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        int bits = IntPtr.Size * 8;
        int crossing = IntPtr.Size == 8 ? 33 : 17;
        Check(Shift(1, crossing) == unchecked((nint)(1L << crossing)), "shift-crosses-fixed-int-width");
        Check(Shift(5, bits) == 5, "full-width-count-masks-to-zero");
        Check(Shift(5, bits + 1) == 10, "full-width-plus-one");
        nint top = unchecked((nint)((nuint)1 << (bits - 1)));
        Check(Shift(1, -1) == top, "negative-count-mask");
        nint negative = -65;
        Check((negative >> 3) == -9, "signed-right-shift-sign-extension");
        nuint unsignedTop = unchecked((nuint)top);
        Check((unsignedTop >> (bits - 1)) == 1, "unsigned-right-shift-zero-extension");
        Check(checked(unsignedTop << 1) == 0, "shift-discards-high-bits-even-checked");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
