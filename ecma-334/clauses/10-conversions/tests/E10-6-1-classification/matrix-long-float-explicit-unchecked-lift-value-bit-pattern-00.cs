/*
Rules: E10-6-1-classification; E10-6-1-nonnull
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
            long? input = long.MinValue;
            float? result = unchecked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==3741319168U, "nullable-long-float-explicit-unchecked-lift-0");
        }
        {
            long? input = 9223372036854775807L;
            float? result = unchecked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1593835520U, "nullable-long-float-explicit-unchecked-lift-1");
        }
        {
            long? input = 0L;
            float? result = unchecked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==0U, "nullable-long-float-explicit-unchecked-lift-2");
        }
        {
            long? input = 1L;
            float? result = unchecked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1065353216U, "nullable-long-float-explicit-unchecked-lift-3");
        }
        {
            long? input = -1L;
            float? result = unchecked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==3212836864U, "nullable-long-float-explicit-unchecked-lift-4");
        }
        {
            long? input = 16777215L;
            float? result = unchecked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1266679807U, "nullable-long-float-explicit-unchecked-lift-5");
        }
        {
            long? input = 16777216L;
            float? result = unchecked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1266679808U, "nullable-long-float-explicit-unchecked-lift-6");
        }
        {
            long? input = 16777217L;
            float? result = unchecked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==1266679808U, "nullable-long-float-explicit-unchecked-lift-7");
        }
        {
            long? input = -16777217L;
            float? result = unchecked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==3414163456U, "nullable-long-float-explicit-unchecked-lift-8");
        }
        {
            long? input = -16777216L;
            float? result = unchecked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==3414163456U, "nullable-long-float-explicit-unchecked-lift-9");
        }
        {
            long? input = -16777215L;
            float? result = unchecked((float?)input);
            Check(result.HasValue && unchecked((uint)BitConverter.SingleToInt32Bits(result.Value))==3414163455U, "nullable-long-float-explicit-unchecked-lift-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
