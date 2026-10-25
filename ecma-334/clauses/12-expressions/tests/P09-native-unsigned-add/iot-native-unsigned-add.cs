/*
Rules: P09-native-unsigned-add
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 4
Mutate: checked(left + right)
Into: unchecked(left + right)
*/
using System;
class Program
{
    static int checks, failures;
    static nuint Add(nuint left, nuint right) { return checked(left + right); }
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        nint minusOne = -1;
        nuint max = unchecked((nuint)minusOne);
        Check(Add(19, 14) == 33, "unsigned-add-value");
        nuint edge = uint.MaxValue;
        var next = unchecked(edge + 1);
        Check((ulong)next == (IntPtr.Size == 8 ? 4294967296UL : 0UL), "unsigned-add-at-native-width");
        Check(unchecked(max + 1) == 0, "unchecked-unsigned-wrap");
        bool trapped = false;
        try { nuint result = Add(max, 1); }
        catch (OverflowException) { trapped = true; }
        Check(trapped, "checked-unsigned-overflow");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
