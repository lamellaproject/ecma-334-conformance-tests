/*
Rules: E10-6-1-classification; E10-6-1-wrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 6
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
            ulong input = 0UL;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==0U, "nullable-ulong-float-explicit-checked-wrap-0");
        }
        {
            ulong input = 18446744073709551615UL;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1602224128U, "nullable-ulong-float-explicit-checked-wrap-1");
        }
        {
            ulong input = 1UL;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1065353216U, "nullable-ulong-float-explicit-checked-wrap-2");
        }
        {
            ulong input = 16777215UL;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1266679807U, "nullable-ulong-float-explicit-checked-wrap-3");
        }
        {
            ulong input = 16777216UL;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1266679808U, "nullable-ulong-float-explicit-checked-wrap-4");
        }
        {
            ulong input = 16777217UL;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1266679808U, "nullable-ulong-float-explicit-checked-wrap-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
