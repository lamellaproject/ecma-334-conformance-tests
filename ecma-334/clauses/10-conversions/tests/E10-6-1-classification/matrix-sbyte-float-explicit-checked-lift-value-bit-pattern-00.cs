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
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==3271557120U, "nullable-sbyte-float-explicit-checked-lift-0");
        }
        {
            sbyte? input = (sbyte)(127);
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1123942400U, "nullable-sbyte-float-explicit-checked-lift-1");
        }
        {
            sbyte? input = (sbyte)(0);
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==0U, "nullable-sbyte-float-explicit-checked-lift-2");
        }
        {
            sbyte? input = (sbyte)(1);
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1065353216U, "nullable-sbyte-float-explicit-checked-lift-3");
        }
        {
            sbyte? input = (sbyte)(-1);
            float? result = checked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==3212836864U, "nullable-sbyte-float-explicit-checked-lift-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
