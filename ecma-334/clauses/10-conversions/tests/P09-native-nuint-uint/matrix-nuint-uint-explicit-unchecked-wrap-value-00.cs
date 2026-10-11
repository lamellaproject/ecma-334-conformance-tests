/*
Rules: P09-native-nuint-uint; P09-native-nullable-wrap
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 6
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
            uint? result = unchecked((uint?)input);
            Check(result.HasValue && result.Value==0U, "nuint-uint-explicit-unchecked-wrap-0");
        }
        {
            nuint input = (nuint)(18446744073709551615UL);
            uint? result = unchecked((uint?)input);
            Check(result.HasValue && result.Value==4294967295U, "nuint-uint-explicit-unchecked-wrap-1");
        }
        {
            nuint input = (nuint)(1UL);
            uint? result = unchecked((uint?)input);
            Check(result.HasValue && result.Value==1U, "nuint-uint-explicit-unchecked-wrap-2");
        }
        {
            nuint input = (nuint)(4294967294UL);
            uint? result = unchecked((uint?)input);
            Check(result.HasValue && result.Value==4294967294U, "nuint-uint-explicit-unchecked-wrap-3");
        }
        {
            nuint input = (nuint)(4294967295UL);
            uint? result = unchecked((uint?)input);
            Check(result.HasValue && result.Value==4294967295U, "nuint-uint-explicit-unchecked-wrap-4");
        }
        {
            nuint input = (nuint)(4294967296UL);
            uint? result = unchecked((uint?)input);
            Check(result.HasValue && result.Value==0U, "nuint-uint-explicit-unchecked-wrap-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
