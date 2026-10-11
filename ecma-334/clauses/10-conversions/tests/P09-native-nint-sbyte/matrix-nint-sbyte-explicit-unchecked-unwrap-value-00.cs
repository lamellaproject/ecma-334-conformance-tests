/*
Rules: P09-native-nint-sbyte; P09-native-nullable-unwrap
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 11
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
            nint? input = (nint)(long.MinValue);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(0), "nint-sbyte-explicit-unchecked-unwrap-0");
        }
        {
            nint? input = (nint)(9223372036854775807L);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-1), "nint-sbyte-explicit-unchecked-unwrap-1");
        }
        {
            nint? input = (nint)(0L);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(0), "nint-sbyte-explicit-unchecked-unwrap-2");
        }
        {
            nint? input = (nint)(1L);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(1), "nint-sbyte-explicit-unchecked-unwrap-3");
        }
        {
            nint? input = (nint)(-1L);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-1), "nint-sbyte-explicit-unchecked-unwrap-4");
        }
        {
            nint? input = (nint)(-129L);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(127), "nint-sbyte-explicit-unchecked-unwrap-5");
        }
        {
            nint? input = (nint)(-128L);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-128), "nint-sbyte-explicit-unchecked-unwrap-6");
        }
        {
            nint? input = (nint)(-127L);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-127), "nint-sbyte-explicit-unchecked-unwrap-7");
        }
        {
            nint? input = (nint)(126L);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(126), "nint-sbyte-explicit-unchecked-unwrap-8");
        }
        {
            nint? input = (nint)(127L);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(127), "nint-sbyte-explicit-unchecked-unwrap-9");
        }
        {
            nint? input = (nint)(128L);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-128), "nint-sbyte-explicit-unchecked-unwrap-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
