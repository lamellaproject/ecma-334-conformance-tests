/*
Rules: E10-3-2-all-pairs; E10-3-2-double; E12-23-numeric
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
            const double input = 0.0d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==0U, "double-float-explicit-checked-constant-2");
        }
        {
            const double input = -0.0d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==2147483648U, "double-float-explicit-checked-constant-3");
        }
        {
            const double input = 1.0d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1065353216U, "double-float-explicit-checked-constant-4");
        }
        {
            const double input = -1.0d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3212836864U, "double-float-explicit-checked-constant-5");
        }
        {
            const double input = 0.75d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1061158912U, "double-float-explicit-checked-constant-6");
        }
        {
            const double input = -0.75d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3208642560U, "double-float-explicit-checked-constant-7");
        }
        {
            const double input = 16777215.0d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679807U, "double-float-explicit-checked-constant-11");
        }
        {
            const double input = 16777216.0d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "double-float-explicit-checked-constant-12");
        }
        {
            const double input = 16777217.0d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "double-float-explicit-checked-constant-13");
        }
        {
            const double input = -16777217.0d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163456U, "double-float-explicit-checked-constant-14");
        }
        {
            const double input = -16777216.0d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163456U, "double-float-explicit-checked-constant-15");
        }
        {
            const double input = -16777215.0d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163455U, "double-float-explicit-checked-constant-16");
        }
        {
            const double input = 1.0000000596046448d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1065353216U, "double-float-explicit-checked-constant-17");
        }
        {
            const double input = 1e-300d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==0U, "double-float-explicit-checked-constant-20");
        }
        {
            const double input = -1e-300d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==2147483648U, "double-float-explicit-checked-constant-21");
        }
        {
            const double input = 7.0064923216240854e-46d;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==0U, "double-float-explicit-checked-constant-22");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
