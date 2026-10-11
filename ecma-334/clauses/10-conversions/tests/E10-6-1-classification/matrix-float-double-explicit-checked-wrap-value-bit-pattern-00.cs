/*
Rules: E10-6-1-classification; E10-6-1-wrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 10
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
            float input = -3.40282347e+38f;
            double? result = checked((double?)input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==14407015207421345792UL, "nullable-float-double-explicit-checked-wrap-0");
        }
        {
            float input = 3.40282347e+38f;
            double? result = checked((double?)input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==5183643170566569984UL, "nullable-float-double-explicit-checked-wrap-1");
        }
        {
            float input = 0.0f;
            double? result = checked((double?)input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==0UL, "nullable-float-double-explicit-checked-wrap-2");
        }
        {
            float input = -0.0f;
            double? result = checked((double?)input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==9223372036854775808UL, "nullable-float-double-explicit-checked-wrap-3");
        }
        {
            float input = 1.0f;
            double? result = checked((double?)input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4607182418800017408UL, "nullable-float-double-explicit-checked-wrap-4");
        }
        {
            float input = -1.0f;
            double? result = checked((double?)input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==13830554455654793216UL, "nullable-float-double-explicit-checked-wrap-5");
        }
        {
            float input = 0.75f;
            double? result = checked((double?)input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4604930618986332160UL, "nullable-float-double-explicit-checked-wrap-6");
        }
        {
            float input = -0.75f;
            double? result = checked((double?)input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==13828302655841107968UL, "nullable-float-double-explicit-checked-wrap-7");
        }
        {
            float input = 9.00719925e+15f;
            double? result = checked((double?)input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4845873199050653696UL, "nullable-float-double-explicit-checked-wrap-11");
        }
        {
            float input = -9.00719925e+15f;
            double? result = checked((double?)input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==14069245235905429504UL, "nullable-float-double-explicit-checked-wrap-12");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
