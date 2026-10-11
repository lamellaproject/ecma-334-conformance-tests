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
            int input = -2147483648;
            float? result = checked(input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==3472883712U, "nullable-int-float-implicit-checked-wrap-0");
        }
        {
            int input = 2147483647;
            float? result = checked(input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1325400064U, "nullable-int-float-implicit-checked-wrap-1");
        }
        {
            int input = 0;
            float? result = checked(input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==0U, "nullable-int-float-implicit-checked-wrap-2");
        }
        {
            int input = 1;
            float? result = checked(input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1065353216U, "nullable-int-float-implicit-checked-wrap-3");
        }
        {
            int input = -1;
            float? result = checked(input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==3212836864U, "nullable-int-float-implicit-checked-wrap-4");
        }
        {
            int input = 16777215;
            float? result = checked(input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1266679807U, "nullable-int-float-implicit-checked-wrap-5");
        }
        {
            int input = 16777216;
            float? result = checked(input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1266679808U, "nullable-int-float-implicit-checked-wrap-6");
        }
        {
            int input = 16777217;
            float? result = checked(input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1266679808U, "nullable-int-float-implicit-checked-wrap-7");
        }
        {
            int input = -16777217;
            float? result = checked(input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==3414163456U, "nullable-int-float-implicit-checked-wrap-8");
        }
        {
            int input = -16777216;
            float? result = checked(input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==3414163456U, "nullable-int-float-implicit-checked-wrap-9");
        }
        {
            int input = -16777215;
            float? result = checked(input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==3414163455U, "nullable-int-float-implicit-checked-wrap-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
