/*
Rules: P09-native-lifted-operators
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 6
Mutate: left + right
Into: (left ?? 0) + (right ?? 0)
*/
using System;
class Program
{
    static int checks, failures;
    static nint? Add(nint? left, nint? right) { return left + right; }
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Check(Add(-12, 5) == -7, "lifted-nonnull-addition");
        Check(Add(null, 5) == null, "left-null-propagates");
        Check(Add(5, null) == null, "right-null-propagates");
        nint? absent = null, present = 5;
        Check((absent < present) == false, "null-relational-is-false");
        Check(absent == null && absent != present, "lifted-equality");
        nuint? u = 3, missing = null;
        Check((u + missing) == null, "unsigned-lifted-null");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
