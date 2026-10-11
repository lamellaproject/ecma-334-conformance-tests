/*
Rules: E10-2-3-long
Authority: ECMA-334 7th ed 10.2.3
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
            long input = long.MinValue;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3741319168U, "long-float-implicit-checked-variable-0");
        }
        {
            long input = 9223372036854775807L;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1593835520U, "long-float-implicit-checked-variable-1");
        }
        {
            long input = 0L;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==0U, "long-float-implicit-checked-variable-2");
        }
        {
            long input = 1L;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1065353216U, "long-float-implicit-checked-variable-3");
        }
        {
            long input = -1L;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3212836864U, "long-float-implicit-checked-variable-4");
        }
        {
            long input = 16777215L;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679807U, "long-float-implicit-checked-variable-5");
        }
        {
            long input = 16777216L;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "long-float-implicit-checked-variable-6");
        }
        {
            long input = 16777217L;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "long-float-implicit-checked-variable-7");
        }
        {
            long input = -16777217L;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163456U, "long-float-implicit-checked-variable-8");
        }
        {
            long input = -16777216L;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163456U, "long-float-implicit-checked-variable-9");
        }
        {
            long input = -16777215L;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163455U, "long-float-implicit-checked-variable-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
