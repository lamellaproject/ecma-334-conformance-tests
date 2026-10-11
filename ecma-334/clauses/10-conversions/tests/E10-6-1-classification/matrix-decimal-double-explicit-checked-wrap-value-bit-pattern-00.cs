/*
Rules: E10-6-1-classification; E10-6-1-wrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 15
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
            decimal input = -79228162514264337593543950335m;
            double? result = checked((double?)input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==14262900019882360832UL, "nullable-decimal-double-explicit-checked-wrap-0");
        }
        {
            decimal input = 79228162514264337593543950335m;
            double? result = checked((double?)input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==5039527983027585024UL, "nullable-decimal-double-explicit-checked-wrap-1");
        }
        {
            decimal input = 0m;
            double? result = checked((double?)input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==0UL, "nullable-decimal-double-explicit-checked-wrap-2");
        }
        {
            decimal input = 1m;
            double? result = checked((double?)input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4607182418800017408UL, "nullable-decimal-double-explicit-checked-wrap-3");
        }
        {
            decimal input = -1m;
            double? result = checked((double?)input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==13830554455654793216UL, "nullable-decimal-double-explicit-checked-wrap-4");
        }
        {
            decimal input = 0.1m;
            double? result = checked((double?)input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4591870180066957722UL, "nullable-decimal-double-explicit-checked-wrap-5");
        }
        {
            decimal input = -0.1m;
            double? result = checked((double?)input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==13815242216921733530UL, "nullable-decimal-double-explicit-checked-wrap-6");
        }
        {
            decimal input = 1E-28m;
            double? result = checked((double?)input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4188260752279232537UL, "nullable-decimal-double-explicit-checked-wrap-7");
        }
        {
            decimal input = -1E-28m;
            double? result = checked((double?)input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==13411632789134008345UL, "nullable-decimal-double-explicit-checked-wrap-8");
        }
        {
            decimal input = 9007199254740991m;
            double? result = checked((double?)input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4845873199050653695UL, "nullable-decimal-double-explicit-checked-wrap-9");
        }
        {
            decimal input = 9007199254740992m;
            double? result = checked((double?)input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4845873199050653696UL, "nullable-decimal-double-explicit-checked-wrap-10");
        }
        {
            decimal input = 9007199254740993m;
            double? result = checked((double?)input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4845873199050653696UL, "nullable-decimal-double-explicit-checked-wrap-11");
        }
        {
            decimal input = -9007199254740993m;
            double? result = checked((double?)input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==14069245235905429504UL, "nullable-decimal-double-explicit-checked-wrap-12");
        }
        {
            decimal input = -9007199254740992m;
            double? result = checked((double?)input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==14069245235905429504UL, "nullable-decimal-double-explicit-checked-wrap-13");
        }
        {
            decimal input = -9007199254740991m;
            double? result = checked((double?)input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==14069245235905429503UL, "nullable-decimal-double-explicit-checked-wrap-14");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
