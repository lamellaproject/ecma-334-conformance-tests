/*
Rules: P09-native-nint-double; P09-native-nullable-unwrap
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
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14114281232179134464UL, "nint-double-explicit-unchecked-unwrap-0");
        }
        {
            nint? input = (nint)(9223372036854775807L);
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4890909195324358656UL, "nint-double-explicit-unchecked-unwrap-1");
        }
        {
            nint? input = (nint)(0L);
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==0UL, "nint-double-explicit-unchecked-unwrap-2");
        }
        {
            nint? input = (nint)(1L);
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4607182418800017408UL, "nint-double-explicit-unchecked-unwrap-3");
        }
        {
            nint? input = (nint)(-1L);
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==13830554455654793216UL, "nint-double-explicit-unchecked-unwrap-4");
        }
        {
            nint? input = (nint)(9007199254740991L);
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653695UL, "nint-double-explicit-unchecked-unwrap-5");
        }
        {
            nint? input = (nint)(9007199254740992L);
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653696UL, "nint-double-explicit-unchecked-unwrap-6");
        }
        {
            nint? input = (nint)(9007199254740993L);
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653696UL, "nint-double-explicit-unchecked-unwrap-7");
        }
        {
            nint? input = (nint)(-9007199254740993L);
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14069245235905429504UL, "nint-double-explicit-unchecked-unwrap-8");
        }
        {
            nint? input = (nint)(-9007199254740992L);
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14069245235905429504UL, "nint-double-explicit-unchecked-unwrap-9");
        }
        {
            nint? input = (nint)(-9007199254740991L);
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14069245235905429503UL, "nint-double-explicit-unchecked-unwrap-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
