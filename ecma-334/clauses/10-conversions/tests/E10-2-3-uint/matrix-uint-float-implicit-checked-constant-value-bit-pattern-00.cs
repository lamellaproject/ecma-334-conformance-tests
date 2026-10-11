/*
Rules: E10-2-3-uint; E12-23-numeric
Authority: ECMA-334 7th ed 10.2.3
Version: 7.3
Expected: run
Stdout: OK 6
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
            const uint input = 0U;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==0U, "uint-float-implicit-checked-constant-0");
        }
        {
            const uint input = 4294967295U;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1333788672U, "uint-float-implicit-checked-constant-1");
        }
        {
            const uint input = 1U;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1065353216U, "uint-float-implicit-checked-constant-2");
        }
        {
            const uint input = 16777215U;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679807U, "uint-float-implicit-checked-constant-3");
        }
        {
            const uint input = 16777216U;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "uint-float-implicit-checked-constant-4");
        }
        {
            const uint input = 16777217U;
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "uint-float-implicit-checked-constant-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
