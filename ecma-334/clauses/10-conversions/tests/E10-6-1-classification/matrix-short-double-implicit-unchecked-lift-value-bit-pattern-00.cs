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
            short? input = (short)(-32768);
            double? result = unchecked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==13898108450065350656UL, "nullable-short-double-implicit-unchecked-lift-0");
        }
        {
            short? input = (short)(32767);
            double? result = unchecked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4674736138332667904UL, "nullable-short-double-implicit-unchecked-lift-1");
        }
        {
            short? input = (short)(0);
            double? result = unchecked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==0UL, "nullable-short-double-implicit-unchecked-lift-2");
        }
        {
            short? input = (short)(1);
            double? result = unchecked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4607182418800017408UL, "nullable-short-double-implicit-unchecked-lift-3");
        }
        {
            short? input = (short)(-1);
            double? result = unchecked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==13830554455654793216UL, "nullable-short-double-implicit-unchecked-lift-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
