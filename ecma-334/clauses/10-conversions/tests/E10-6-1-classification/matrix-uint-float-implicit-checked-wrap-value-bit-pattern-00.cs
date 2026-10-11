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
            uint input = 0U;
            float? result = checked(input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==0U, "nullable-uint-float-implicit-checked-wrap-0");
        }
        {
            uint input = 4294967295U;
            float? result = checked(input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1333788672U, "nullable-uint-float-implicit-checked-wrap-1");
        }
        {
            uint input = 1U;
            float? result = checked(input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1065353216U, "nullable-uint-float-implicit-checked-wrap-2");
        }
        {
            uint input = 16777215U;
            float? result = checked(input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1266679807U, "nullable-uint-float-implicit-checked-wrap-3");
        }
        {
            uint input = 16777216U;
            float? result = checked(input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1266679808U, "nullable-uint-float-implicit-checked-wrap-4");
        }
        {
            uint input = 16777217U;
            float? result = checked(input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1266679808U, "nullable-uint-float-implicit-checked-wrap-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
