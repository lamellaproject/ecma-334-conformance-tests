/*
Rules: P09-native-nuint-sbyte; P09-native-nullable-unwrap
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
            nuint? input = (nuint)(0UL);
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(0), "nuint-sbyte-explicit-checked-unwrap-0");
        }
        {
            nuint? input = (nuint)(1UL);
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(1), "nuint-sbyte-explicit-checked-unwrap-2");
        }
        {
            nuint? input = (nuint)(126UL);
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(126), "nuint-sbyte-explicit-checked-unwrap-3");
        }
        {
            nuint? input = (nuint)(127UL);
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(127), "nuint-sbyte-explicit-checked-unwrap-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
