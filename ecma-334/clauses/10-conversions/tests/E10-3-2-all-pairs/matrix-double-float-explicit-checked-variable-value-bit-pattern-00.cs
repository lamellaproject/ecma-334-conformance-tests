/*
Rules: E10-3-2-all-pairs; E10-3-2-double
Authority: ECMA-334 7th ed 10.3.2
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
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==0U, "double-float-explicit-checked-variable-2");
        }
        {
            double input = -0.0d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==2147483648U, "double-float-explicit-checked-variable-3");
        }
        {
            double input = 1.0d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1065353216U, "double-float-explicit-checked-variable-4");
        }
        {
            double input = -1.0d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3212836864U, "double-float-explicit-checked-variable-5");
        }
        {
            double input = 0.75d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1061158912U, "double-float-explicit-checked-variable-6");
        }
        {
            double input = -0.75d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3208642560U, "double-float-explicit-checked-variable-7");
        }
        {
            double input = 16777215.0d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679807U, "double-float-explicit-checked-variable-11");
        }
        {
            double input = 16777216.0d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "double-float-explicit-checked-variable-12");
        }
        {
            double input = 16777217.0d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "double-float-explicit-checked-variable-13");
        }
        {
            double input = -16777217.0d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163456U, "double-float-explicit-checked-variable-14");
        }
        {
            double input = -16777216.0d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163456U, "double-float-explicit-checked-variable-15");
        }
        {
            double input = -16777215.0d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163455U, "double-float-explicit-checked-variable-16");
        }
        {
            double input = 1.0000000596046448d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1065353216U, "double-float-explicit-checked-variable-17");
        }
        {
            double input = 1e-300d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==0U, "double-float-explicit-checked-variable-20");
        }
        {
            double input = -1e-300d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==2147483648U, "double-float-explicit-checked-variable-21");
        }
        {
            double input = 7.0064923216240854e-46d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==0U, "double-float-explicit-checked-variable-22");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
