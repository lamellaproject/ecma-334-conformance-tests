/*
Rules: P09-native-nuint-nuint; P09-native-nullable-wrap
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 4
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
            nuint input = (nuint)(0UL);
            nuint? result = checked(input);
            Check(result.HasValue && (ulong)result.Value==0UL, "nuint-nuint-implicit-checked-wrap-0");
        }
        {
            nuint input = (nuint)(18446744073709551615UL);
            nuint? result = checked(input);
            Check(result.HasValue && (ulong)result.Value==18446744073709551615UL, "nuint-nuint-implicit-checked-wrap-1");
        }
        {
            nuint input = (nuint)(1UL);
            nuint? result = checked(input);
            Check(result.HasValue && (ulong)result.Value==1UL, "nuint-nuint-implicit-checked-wrap-2");
        }
        {
            nuint input = (nuint)(18446744073709551614UL);
            nuint? result = checked(input);
            Check(result.HasValue && (ulong)result.Value==18446744073709551614UL, "nuint-nuint-implicit-checked-wrap-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
