/*
Rules: E10-6-1-classification; E10-6-1-wrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 16
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
            double input = 0.0d;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==0U, "nullable-double-float-explicit-checked-wrap-2");
        }
        {
            double input = -0.0d;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==2147483648U, "nullable-double-float-explicit-checked-wrap-3");
        }
        {
            double input = 1.0d;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1065353216U, "nullable-double-float-explicit-checked-wrap-4");
        }
        {
            double input = -1.0d;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==3212836864U, "nullable-double-float-explicit-checked-wrap-5");
        }
        {
            double input = 0.75d;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1061158912U, "nullable-double-float-explicit-checked-wrap-6");
        }
        {
            double input = -0.75d;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==3208642560U, "nullable-double-float-explicit-checked-wrap-7");
        }
        {
            double input = 16777215.0d;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1266679807U, "nullable-double-float-explicit-checked-wrap-11");
        }
        {
            double input = 16777216.0d;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1266679808U, "nullable-double-float-explicit-checked-wrap-12");
        }
        {
            double input = 16777217.0d;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1266679808U, "nullable-double-float-explicit-checked-wrap-13");
        }
        {
            double input = -16777217.0d;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==3414163456U, "nullable-double-float-explicit-checked-wrap-14");
        }
        {
            double input = -16777216.0d;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==3414163456U, "nullable-double-float-explicit-checked-wrap-15");
        }
        {
            double input = -16777215.0d;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==3414163455U, "nullable-double-float-explicit-checked-wrap-16");
        }
        {
            double input = 1.0000000596046448d;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1065353216U, "nullable-double-float-explicit-checked-wrap-17");
        }
        {
            double input = 1e-300d;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==0U, "nullable-double-float-explicit-checked-wrap-20");
        }
        {
            double input = -1e-300d;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==2147483648U, "nullable-double-float-explicit-checked-wrap-21");
        }
        {
            double input = 7.0064923216240854e-46d;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==0U, "nullable-double-float-explicit-checked-wrap-22");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
