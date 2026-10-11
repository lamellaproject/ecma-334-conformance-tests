/*
Rules: E10-6-1-classification; E10-6-1-unwrap
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
            double? input = 0.0d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==0U, "nullable-double-float-explicit-checked-unwrap-2");
        }
        {
            double? input = -0.0d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==2147483648U, "nullable-double-float-explicit-checked-unwrap-3");
        }
        {
            double? input = 1.0d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1065353216U, "nullable-double-float-explicit-checked-unwrap-4");
        }
        {
            double? input = -1.0d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3212836864U, "nullable-double-float-explicit-checked-unwrap-5");
        }
        {
            double? input = 0.75d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1061158912U, "nullable-double-float-explicit-checked-unwrap-6");
        }
        {
            double? input = -0.75d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3208642560U, "nullable-double-float-explicit-checked-unwrap-7");
        }
        {
            double? input = 16777215.0d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679807U, "nullable-double-float-explicit-checked-unwrap-11");
        }
        {
            double? input = 16777216.0d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "nullable-double-float-explicit-checked-unwrap-12");
        }
        {
            double? input = 16777217.0d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "nullable-double-float-explicit-checked-unwrap-13");
        }
        {
            double? input = -16777217.0d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163456U, "nullable-double-float-explicit-checked-unwrap-14");
        }
        {
            double? input = -16777216.0d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163456U, "nullable-double-float-explicit-checked-unwrap-15");
        }
        {
            double? input = -16777215.0d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163455U, "nullable-double-float-explicit-checked-unwrap-16");
        }
        {
            double? input = 1.0000000596046448d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1065353216U, "nullable-double-float-explicit-checked-unwrap-17");
        }
        {
            double? input = 1e-300d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==0U, "nullable-double-float-explicit-checked-unwrap-20");
        }
        {
            double? input = -1e-300d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==2147483648U, "nullable-double-float-explicit-checked-unwrap-21");
        }
        {
            double? input = 7.0064923216240854e-46d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==0U, "nullable-double-float-explicit-checked-unwrap-22");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
