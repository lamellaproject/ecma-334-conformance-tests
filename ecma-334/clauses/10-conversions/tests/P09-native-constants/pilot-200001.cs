/*
Rules: P09-native-constants
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 1
Mutate: nint a=(nint)int.MinValue;
Into: nint a=default(nint);
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        const nint a=(nint)int.MinValue; const nint b=(nint)int.MaxValue; const nuint c=(nuint)uint.MaxValue; Check((long)a==-2147483648L && (long)b==2147483647L && (ulong)c==4294967295UL, "P09-native-constants-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
