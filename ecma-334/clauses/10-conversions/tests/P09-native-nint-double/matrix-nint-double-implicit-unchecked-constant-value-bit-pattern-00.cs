/*
Rules: P09-native-nint-double
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
            const nint input = (nint)(0L);
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==0UL, "nint-double-implicit-unchecked-True-2");
        }
        {
            const nint input = (nint)(1L);
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4607182418800017408UL, "nint-double-implicit-unchecked-True-3");
        }
        {
            const nint input = (nint)(-1L);
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==13830554455654793216UL, "nint-double-implicit-unchecked-True-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
