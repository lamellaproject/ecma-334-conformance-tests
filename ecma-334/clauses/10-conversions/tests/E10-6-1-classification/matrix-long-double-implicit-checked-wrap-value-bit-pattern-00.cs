/*
Rules: E10-6-1-classification; E10-6-1-wrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 11
Generated: clauses/10-conversions/generators/standard-matrices.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        {
            long input = long.MinValue;
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==14114281232179134464UL, "nullable-long-double-implicit-checked-wrap-0");
        }
        {
            long input = 9223372036854775807L;
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4890909195324358656UL, "nullable-long-double-implicit-checked-wrap-1");
        }
        {
            long input = 0L;
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==0UL, "nullable-long-double-implicit-checked-wrap-2");
        }
        {
            long input = 1L;
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4607182418800017408UL, "nullable-long-double-implicit-checked-wrap-3");
        }
        {
            long input = -1L;
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==13830554455654793216UL, "nullable-long-double-implicit-checked-wrap-4");
        }
        {
            long input = 9007199254740991L;
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4845873199050653695UL, "nullable-long-double-implicit-checked-wrap-5");
        }
        {
            long input = 9007199254740992L;
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4845873199050653696UL, "nullable-long-double-implicit-checked-wrap-6");
        }
        {
            long input = 9007199254740993L;
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4845873199050653696UL, "nullable-long-double-implicit-checked-wrap-7");
        }
        {
            long input = -9007199254740993L;
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==14069245235905429504UL, "nullable-long-double-implicit-checked-wrap-8");
        }
        {
            long input = -9007199254740992L;
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==14069245235905429504UL, "nullable-long-double-implicit-checked-wrap-9");
        }
        {
            long input = -9007199254740991L;
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==14069245235905429503UL, "nullable-long-double-implicit-checked-wrap-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
