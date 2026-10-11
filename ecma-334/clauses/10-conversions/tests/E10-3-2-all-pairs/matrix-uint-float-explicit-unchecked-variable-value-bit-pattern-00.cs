/*
Rules: E10-3-2-all-pairs; E10-3-2-uint
Authority: ECMA-334 7th ed 10.3.2
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
            uint input = 0U;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==0U, "uint-float-explicit-unchecked-variable-0");
        }
        {
            uint input = 4294967295U;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1333788672U, "uint-float-explicit-unchecked-variable-1");
        }
        {
            uint input = 1U;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1065353216U, "uint-float-explicit-unchecked-variable-2");
        }
        {
            uint input = 16777215U;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679807U, "uint-float-explicit-unchecked-variable-3");
        }
        {
            uint input = 16777216U;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "uint-float-explicit-unchecked-variable-4");
        }
        {
            uint input = 16777217U;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "uint-float-explicit-unchecked-variable-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
