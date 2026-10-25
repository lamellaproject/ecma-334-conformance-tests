/*
Rules: P09-native-binary-promotion
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 5
Mutate: Kind(n + u)
Into: Kind(n + (int)u)
*/
using System;
class Program
{
    static int checks, failures;
    static int Kind(nint value) { return 1; }
    static int Kind(long value) { return 2; }
    static int Kind(nuint value) { return 3; }
    static int Kind(ulong value) { return 4; }
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        nint n = -7;
        nuint un = 50;
        int i = 2;
        uint u = 9;
        long l = 43;
        ulong ul = 14;
        Check(Kind(n + i) == 1 && n + i == -5, "native-plus-int-stays-native");
        Check(Kind(n + u) == 2 && n + u == 2, "native-plus-uint-promotes-long");
        Check(Kind(n + l) == 2 && n + l == 36, "native-plus-long");
        Check(Kind(un + u) == 3 && un + u == 59, "unsigned-native-plus-uint");
        Check(Kind(un + ul) == 4 && un + ul == 64, "unsigned-native-plus-ulong");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
