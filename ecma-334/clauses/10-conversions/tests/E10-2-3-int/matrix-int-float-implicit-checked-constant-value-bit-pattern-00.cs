/*
Rules: E10-2-3-int; E12-23-numeric
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
            const int input = -2147483648;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3472883712U, "int-float-implicit-checked-constant-0");
        }
        {
            const int input = 2147483647;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1325400064U, "int-float-implicit-checked-constant-1");
        }
        {
            const int input = 0;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==0U, "int-float-implicit-checked-constant-2");
        }
        {
            const int input = 1;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1065353216U, "int-float-implicit-checked-constant-3");
        }
        {
            const int input = -1;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3212836864U, "int-float-implicit-checked-constant-4");
        }
        {
            const int input = 16777215;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679807U, "int-float-implicit-checked-constant-5");
        }
        {
            const int input = 16777216;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "int-float-implicit-checked-constant-6");
        }
        {
            const int input = 16777217;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "int-float-implicit-checked-constant-7");
        }
        {
            const int input = -16777217;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163456U, "int-float-implicit-checked-constant-8");
        }
        {
            const int input = -16777216;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163456U, "int-float-implicit-checked-constant-9");
        }
        {
            const int input = -16777215;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163455U, "int-float-implicit-checked-constant-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
