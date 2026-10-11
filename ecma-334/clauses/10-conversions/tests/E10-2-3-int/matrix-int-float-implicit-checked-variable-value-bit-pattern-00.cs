/*
Rules: E10-2-3-int
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
            int input = -2147483648;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3472883712U, "int-float-implicit-checked-variable-0");
        }
        {
            int input = 2147483647;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1325400064U, "int-float-implicit-checked-variable-1");
        }
        {
            int input = 0;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==0U, "int-float-implicit-checked-variable-2");
        }
        {
            int input = 1;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1065353216U, "int-float-implicit-checked-variable-3");
        }
        {
            int input = -1;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3212836864U, "int-float-implicit-checked-variable-4");
        }
        {
            int input = 16777215;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679807U, "int-float-implicit-checked-variable-5");
        }
        {
            int input = 16777216;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "int-float-implicit-checked-variable-6");
        }
        {
            int input = 16777217;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "int-float-implicit-checked-variable-7");
        }
        {
            int input = -16777217;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163456U, "int-float-implicit-checked-variable-8");
        }
        {
            int input = -16777216;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163456U, "int-float-implicit-checked-variable-9");
        }
        {
            int input = -16777215;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163455U, "int-float-implicit-checked-variable-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
