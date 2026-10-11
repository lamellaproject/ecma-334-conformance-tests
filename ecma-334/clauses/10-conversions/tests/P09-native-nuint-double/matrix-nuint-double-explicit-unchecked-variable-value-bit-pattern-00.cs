/*
Rules: P09-native-nuint-double
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
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==0UL, "nuint-double-explicit-unchecked-False-0");
        }
        {
            nuint input = (nuint)(18446744073709551615UL);
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4895412794951729152UL, "nuint-double-explicit-unchecked-False-1");
        }
        {
            nuint input = (nuint)(1UL);
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4607182418800017408UL, "nuint-double-explicit-unchecked-False-2");
        }
        {
            nuint input = (nuint)(9007199254740991UL);
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653695UL, "nuint-double-explicit-unchecked-False-3");
        }
        {
            nuint input = (nuint)(9007199254740992UL);
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653696UL, "nuint-double-explicit-unchecked-False-4");
        }
        {
            nuint input = (nuint)(9007199254740993UL);
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653696UL, "nuint-double-explicit-unchecked-False-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
