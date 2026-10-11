/*
Rules: P09-native-nuint-double; P09-native-nullable-lift
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
            double? result = unchecked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==0UL, "nuint-double-implicit-unchecked-lift-0");
        }
        {
            nuint? input = (nuint)(18446744073709551615UL);
            double? result = unchecked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4895412794951729152UL, "nuint-double-implicit-unchecked-lift-1");
        }
        {
            nuint? input = (nuint)(1UL);
            double? result = unchecked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4607182418800017408UL, "nuint-double-implicit-unchecked-lift-2");
        }
        {
            nuint? input = (nuint)(9007199254740991UL);
            double? result = unchecked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4845873199050653695UL, "nuint-double-implicit-unchecked-lift-3");
        }
        {
            nuint? input = (nuint)(9007199254740992UL);
            double? result = unchecked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4845873199050653696UL, "nuint-double-implicit-unchecked-lift-4");
        }
        {
            nuint? input = (nuint)(9007199254740993UL);
            double? result = unchecked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4845873199050653696UL, "nuint-double-implicit-unchecked-lift-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
