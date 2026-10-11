/*
Rules: E10-6-1-classification; E10-6-1-wrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 3
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
            uint input = 0U;
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==0UL, "nullable-uint-double-implicit-checked-wrap-0");
        }
        {
            uint input = 4294967295U;
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4751297606873776128UL, "nullable-uint-double-implicit-checked-wrap-1");
        }
        {
            uint input = 1U;
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4607182418800017408UL, "nullable-uint-double-implicit-checked-wrap-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
