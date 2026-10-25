/*
Rules: P09-native-signed-add
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 5
Mutate: checked(left + right)
Into: unchecked(left + right)
*/
using System;
class Program
{
    static int checks, failures;
    static nint Add(nint left, nint right) { return checked(left + right); }
    static int Kind(nint value) { return 1; }
    static int Kind(long value) { return 2; }
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        int bits = IntPtr.Size * 8;
        nint min = unchecked((nint)(1L << (bits - 1)));
        nint max = ~min;
        Check(Add(21, 13) == 34, "signed-add-value");
        nint boundary = int.MaxValue;
        var wide = unchecked(boundary + 1);
        Check((long)wide == (IntPtr.Size == 8 ? 2147483648L : -2147483648L), "addition-at-native-width");
        Check(Kind(wide) == 1, "addition-result-native-type");
        Check(unchecked(max + 1) == min, "unchecked-signed-wrap");
        bool trapped = false;
        try { nint result = Add(max, 1); }
        catch (OverflowException) { trapped = true; }
        Check(trapped, "checked-signed-overflow");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
