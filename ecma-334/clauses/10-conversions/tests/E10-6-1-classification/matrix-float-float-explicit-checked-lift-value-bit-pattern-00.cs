/*
Rules: E10-6-1-classification; E10-6-1-nonnull
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 12
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
            float? input = -3.40282347e+38f;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==4286578687U, "nullable-float-float-explicit-checked-lift-0");
        }
        {
            float? input = 3.40282347e+38f;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==2139095039U, "nullable-float-float-explicit-checked-lift-1");
        }
        {
            float? input = 0.0f;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==0U, "nullable-float-float-explicit-checked-lift-2");
        }
        {
            float? input = -0.0f;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==2147483648U, "nullable-float-float-explicit-checked-lift-3");
        }
        {
            float? input = 1.0f;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1065353216U, "nullable-float-float-explicit-checked-lift-4");
        }
        {
            float? input = -1.0f;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==3212836864U, "nullable-float-float-explicit-checked-lift-5");
        }
        {
            float? input = 0.75f;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1061158912U, "nullable-float-float-explicit-checked-lift-6");
        }
        {
            float? input = -0.75f;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==3208642560U, "nullable-float-float-explicit-checked-lift-7");
        }
        {
            float? input = 16777215.0f;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1266679807U, "nullable-float-float-explicit-checked-lift-11");
        }
        {
            float? input = 16777216.0f;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1266679808U, "nullable-float-float-explicit-checked-lift-12");
        }
        {
            float? input = -16777216.0f;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==3414163456U, "nullable-float-float-explicit-checked-lift-13");
        }
        {
            float? input = -16777215.0f;
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==3414163455U, "nullable-float-float-explicit-checked-lift-14");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
