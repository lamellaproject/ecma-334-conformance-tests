/*
Rules: P09-native-nuint-sbyte
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
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(0), "nuint-sbyte-explicit-unchecked-False-0");
        }
        {
            nuint input = (nuint)(18446744073709551615UL);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-1), "nuint-sbyte-explicit-unchecked-False-1");
        }
        {
            nuint input = (nuint)(1UL);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(1), "nuint-sbyte-explicit-unchecked-False-2");
        }
        {
            nuint input = (nuint)(126UL);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(126), "nuint-sbyte-explicit-unchecked-False-3");
        }
        {
            nuint input = (nuint)(127UL);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(127), "nuint-sbyte-explicit-unchecked-False-4");
        }
        {
            nuint input = (nuint)(128UL);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-128), "nuint-sbyte-explicit-unchecked-False-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
