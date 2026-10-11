/*
Rules: P09-native-nuint-int; P09-native-nullable-lift
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
            nuint? input = (nuint)(0UL);
            int? result = unchecked((int?)input);
            Check(result.HasValue && result.Value==0, "nuint-int-explicit-unchecked-lift-0");
        }
        {
            nuint? input = (nuint)(18446744073709551615UL);
            int? result = unchecked((int?)input);
            Check(result.HasValue && result.Value==-1, "nuint-int-explicit-unchecked-lift-1");
        }
        {
            nuint? input = (nuint)(1UL);
            int? result = unchecked((int?)input);
            Check(result.HasValue && result.Value==1, "nuint-int-explicit-unchecked-lift-2");
        }
        {
            nuint? input = (nuint)(2147483646UL);
            int? result = unchecked((int?)input);
            Check(result.HasValue && result.Value==2147483646, "nuint-int-explicit-unchecked-lift-3");
        }
        {
            nuint? input = (nuint)(2147483647UL);
            int? result = unchecked((int?)input);
            Check(result.HasValue && result.Value==2147483647, "nuint-int-explicit-unchecked-lift-4");
        }
        {
            nuint? input = (nuint)(2147483648UL);
            int? result = unchecked((int?)input);
            Check(result.HasValue && result.Value==-2147483648, "nuint-int-explicit-unchecked-lift-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
