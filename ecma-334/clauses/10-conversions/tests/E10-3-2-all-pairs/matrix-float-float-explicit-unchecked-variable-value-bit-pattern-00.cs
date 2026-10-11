/*
Rules: E10-3-2-all-pairs
Authority: ECMA-334 7th ed 10.3.2
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
            float input = -3.40282347e+38f;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==4286578687U, "float-float-explicit-unchecked-variable-0");
        }
        {
            float input = 3.40282347e+38f;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==2139095039U, "float-float-explicit-unchecked-variable-1");
        }
        {
            float input = 0.0f;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==0U, "float-float-explicit-unchecked-variable-2");
        }
        {
            float input = -0.0f;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==2147483648U, "float-float-explicit-unchecked-variable-3");
        }
        {
            float input = 1.0f;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1065353216U, "float-float-explicit-unchecked-variable-4");
        }
        {
            float input = -1.0f;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3212836864U, "float-float-explicit-unchecked-variable-5");
        }
        {
            float input = 0.75f;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1061158912U, "float-float-explicit-unchecked-variable-6");
        }
        {
            float input = -0.75f;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3208642560U, "float-float-explicit-unchecked-variable-7");
        }
        {
            float input = 16777215.0f;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679807U, "float-float-explicit-unchecked-variable-11");
        }
        {
            float input = 16777216.0f;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "float-float-explicit-unchecked-variable-12");
        }
        {
            float input = -16777216.0f;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163456U, "float-float-explicit-unchecked-variable-13");
        }
        {
            float input = -16777215.0f;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163455U, "float-float-explicit-unchecked-variable-14");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
