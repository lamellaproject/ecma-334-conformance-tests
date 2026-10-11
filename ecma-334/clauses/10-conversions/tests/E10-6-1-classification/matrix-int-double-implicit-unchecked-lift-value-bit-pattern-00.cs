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
            int? input = -2147483648;
            double? result = unchecked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==13970166044103278592UL, "nullable-int-double-implicit-unchecked-lift-0");
        }
        {
            int? input = 2147483647;
            double? result = unchecked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4746794007244308480UL, "nullable-int-double-implicit-unchecked-lift-1");
        }
        {
            int? input = 0;
            double? result = unchecked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==0UL, "nullable-int-double-implicit-unchecked-lift-2");
        }
        {
            int? input = 1;
            double? result = unchecked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4607182418800017408UL, "nullable-int-double-implicit-unchecked-lift-3");
        }
        {
            int? input = -1;
            double? result = unchecked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==13830554455654793216UL, "nullable-int-double-implicit-unchecked-lift-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
