/*
Rules: P09-native-boxing; P09-native-identity; P09-native-compound-identity
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 4
Mutate: object box = value;
Into: object box = (long)value;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        nint value = -41;
        object box = value;
        Check(box is IntPtr, "native-box-underlying-type");
        nint restored = 0;
        bool unboxed = false;
        try { restored = (nint)box; unboxed = true; }
        catch (InvalidCastException) { }
        Check(unboxed && restored == -41, "native-unbox-value");
        bool mismatch = false;
        object fixedBox = -41;
        try { nint wrong = (nint)fixedBox; }
        catch (InvalidCastException) { mismatch = true; }
        Check(mismatch, "fixed-int-box-is-not-native-box");
        nint[] native = new nint[] { 67 };
        IntPtr[] underlying = native;
        Check(object.ReferenceEquals(native, underlying) && (long)underlying[0] == 67, "array-identity-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
