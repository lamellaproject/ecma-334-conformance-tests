/*
Rules: E10-6-1-classification; E10-6-1-nonnull
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 5
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
            sbyte? input = (sbyte)(-128);
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==13862079653046386688UL, "nullable-sbyte-double-implicit-checked-lift-0");
        }
        {
            sbyte? input = (sbyte)(127);
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4638637247447433216UL, "nullable-sbyte-double-implicit-checked-lift-1");
        }
        {
            sbyte? input = (sbyte)(0);
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==0UL, "nullable-sbyte-double-implicit-checked-lift-2");
        }
        {
            sbyte? input = (sbyte)(1);
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4607182418800017408UL, "nullable-sbyte-double-implicit-checked-lift-3");
        }
        {
            sbyte? input = (sbyte)(-1);
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==13830554455654793216UL, "nullable-sbyte-double-implicit-checked-lift-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
