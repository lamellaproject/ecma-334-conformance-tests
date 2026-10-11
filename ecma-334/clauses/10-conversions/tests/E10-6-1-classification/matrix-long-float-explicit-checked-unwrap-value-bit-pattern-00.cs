/*
Rules: E10-6-1-classification; E10-6-1-unwrap
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
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3741319168U, "nullable-long-float-explicit-checked-unwrap-0");
        }
        {
            long? input = 9223372036854775807L;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1593835520U, "nullable-long-float-explicit-checked-unwrap-1");
        }
        {
            long? input = 0L;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==0U, "nullable-long-float-explicit-checked-unwrap-2");
        }
        {
            long? input = 1L;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1065353216U, "nullable-long-float-explicit-checked-unwrap-3");
        }
        {
            long? input = -1L;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3212836864U, "nullable-long-float-explicit-checked-unwrap-4");
        }
        {
            long? input = 16777215L;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679807U, "nullable-long-float-explicit-checked-unwrap-5");
        }
        {
            long? input = 16777216L;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "nullable-long-float-explicit-checked-unwrap-6");
        }
        {
            long? input = 16777217L;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "nullable-long-float-explicit-checked-unwrap-7");
        }
        {
            long? input = -16777217L;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163456U, "nullable-long-float-explicit-checked-unwrap-8");
        }
        {
            long? input = -16777216L;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163456U, "nullable-long-float-explicit-checked-unwrap-9");
        }
        {
            long? input = -16777215L;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163455U, "nullable-long-float-explicit-checked-unwrap-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
