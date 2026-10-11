/*
Rules: P09-native-nuint-sbyte
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
            const nuint input = (nuint)(0UL);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(0), "nuint-sbyte-explicit-unchecked-True-0");
        }
        {
            const nuint input = (nuint)(1UL);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(1), "nuint-sbyte-explicit-unchecked-True-2");
        }
        {
            const nuint input = (nuint)(126UL);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(126), "nuint-sbyte-explicit-unchecked-True-3");
        }
        {
            const nuint input = (nuint)(127UL);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(127), "nuint-sbyte-explicit-unchecked-True-4");
        }
        {
            const nuint input = (nuint)(128UL);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-128), "nuint-sbyte-explicit-unchecked-True-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
