/*
Rules: P09-native-sbyte-nint; P09-native-nullable-wrap
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 5
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
            sbyte input = (sbyte)(-128);
            nint? result = unchecked(input);
            Check(result.HasValue && (long)result.Value==-128L, "sbyte-nint-implicit-unchecked-wrap-0");
        }
        {
            sbyte input = (sbyte)(127);
            nint? result = unchecked(input);
            Check(result.HasValue && (long)result.Value==127L, "sbyte-nint-implicit-unchecked-wrap-1");
        }
        {
            sbyte input = (sbyte)(0);
            nint? result = unchecked(input);
            Check(result.HasValue && (long)result.Value==0L, "sbyte-nint-implicit-unchecked-wrap-2");
        }
        {
            sbyte input = (sbyte)(1);
            nint? result = unchecked(input);
            Check(result.HasValue && (long)result.Value==1L, "sbyte-nint-implicit-unchecked-wrap-3");
        }
        {
            sbyte input = (sbyte)(-1);
            nint? result = unchecked(input);
            Check(result.HasValue && (long)result.Value==-1L, "sbyte-nint-implicit-unchecked-wrap-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
