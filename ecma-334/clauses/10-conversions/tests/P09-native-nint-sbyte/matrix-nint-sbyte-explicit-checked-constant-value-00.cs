/*
Rules: P09-native-nint-sbyte
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 7
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
            const nint input = (nint)(0L);
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(0), "nint-sbyte-explicit-checked-True-2");
        }
        {
            const nint input = (nint)(1L);
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(1), "nint-sbyte-explicit-checked-True-3");
        }
        {
            const nint input = (nint)(-1L);
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(-1), "nint-sbyte-explicit-checked-True-4");
        }
        {
            const nint input = (nint)(-128L);
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(-128), "nint-sbyte-explicit-checked-True-6");
        }
        {
            const nint input = (nint)(-127L);
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(-127), "nint-sbyte-explicit-checked-True-7");
        }
        {
            const nint input = (nint)(126L);
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(126), "nint-sbyte-explicit-checked-True-8");
        }
        {
            const nint input = (nint)(127L);
            sbyte result = checked((sbyte)input);
            Check(result==(sbyte)(127), "nint-sbyte-explicit-checked-True-9");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
