/*
Rules: P09-native-nint-double; P09-native-nullable-lift
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
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==14114281232179134464UL, "nint-double-implicit-checked-lift-0");
        }
        {
            nint? input = (nint)(9223372036854775807L);
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4890909195324358656UL, "nint-double-implicit-checked-lift-1");
        }
        {
            nint? input = (nint)(0L);
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==0UL, "nint-double-implicit-checked-lift-2");
        }
        {
            nint? input = (nint)(1L);
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4607182418800017408UL, "nint-double-implicit-checked-lift-3");
        }
        {
            nint? input = (nint)(-1L);
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==13830554455654793216UL, "nint-double-implicit-checked-lift-4");
        }
        {
            nint? input = (nint)(9007199254740991L);
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4845873199050653695UL, "nint-double-implicit-checked-lift-5");
        }
        {
            nint? input = (nint)(9007199254740992L);
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4845873199050653696UL, "nint-double-implicit-checked-lift-6");
        }
        {
            nint? input = (nint)(9007199254740993L);
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4845873199050653696UL, "nint-double-implicit-checked-lift-7");
        }
        {
            nint? input = (nint)(-9007199254740993L);
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==14069245235905429504UL, "nint-double-implicit-checked-lift-8");
        }
        {
            nint? input = (nint)(-9007199254740992L);
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==14069245235905429504UL, "nint-double-implicit-checked-lift-9");
        }
        {
            nint? input = (nint)(-9007199254740991L);
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==14069245235905429503UL, "nint-double-implicit-checked-lift-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
