/*
Rules: P09-native-contextual-name
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 4
Mutate: using nint = System.Int32;
Into: // Native spelling now uses contextual lookup.
*/
using System;
using nint = System.Int32;
using nuint = System.UInt64;
class Program
{
    static int checks, failures;
    static int Kind(int value) { return 1; }
    static int Kind(IntPtr value) { return 2; }
    static int Kind(ulong value) { return 3; }
    static int Kind(UIntPtr value) { return 4; }
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        nint signed = 37;
        nuint unsigned = 59;
        Check(Kind(signed) == 1, "signed-alias-precedes-contextual-name");
        Check(typeof(nint) == typeof(int), "signed-alias-type");
        Check(Kind(unsigned) == 3, "unsigned-alias-precedes-contextual-name");
        Check(typeof(nuint) == typeof(ulong), "unsigned-alias-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
