/*
Rules: P09-native-sbyte-nuint; P09-native-nullable-lift
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 3
Generated: clauses/10-conversions/generators/native-matrices.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        {
            sbyte? input = (sbyte)(127);
            nuint? result = checked((nuint?)input);
            Check(result.HasValue && (ulong)result.Value==127UL, "sbyte-nuint-explicit-checked-lift-1");
        }
        {
            sbyte? input = (sbyte)(0);
            nuint? result = checked((nuint?)input);
            Check(result.HasValue && (ulong)result.Value==0UL, "sbyte-nuint-explicit-checked-lift-2");
        }
        {
            sbyte? input = (sbyte)(1);
            nuint? result = checked((nuint?)input);
            Check(result.HasValue && (ulong)result.Value==1UL, "sbyte-nuint-explicit-checked-lift-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
