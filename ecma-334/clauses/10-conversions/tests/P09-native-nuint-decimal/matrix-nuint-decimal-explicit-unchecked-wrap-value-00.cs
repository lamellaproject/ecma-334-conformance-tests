/*
Rules: P09-native-nuint-decimal; P09-native-nullable-wrap
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
            nuint input = (nuint)(0UL);
            decimal? result = unchecked((decimal?)input);
            Check(result.HasValue && result.Value==0m, "nuint-decimal-explicit-unchecked-wrap-0");
        }
        {
            nuint input = (nuint)(18446744073709551615UL);
            decimal? result = unchecked((decimal?)input);
            Check(result.HasValue && result.Value==18446744073709551615m, "nuint-decimal-explicit-unchecked-wrap-1");
        }
        {
            nuint input = (nuint)(1UL);
            decimal? result = unchecked((decimal?)input);
            Check(result.HasValue && result.Value==1m, "nuint-decimal-explicit-unchecked-wrap-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
