/*
Rules: E10-3-2-all-pairs; E10-3-2-ulong
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
            ulong input = 0UL;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==0U, "ulong-float-explicit-unchecked-variable-0");
        }
        {
            ulong input = 18446744073709551615UL;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1602224128U, "ulong-float-explicit-unchecked-variable-1");
        }
        {
            ulong input = 1UL;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1065353216U, "ulong-float-explicit-unchecked-variable-2");
        }
        {
            ulong input = 16777215UL;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679807U, "ulong-float-explicit-unchecked-variable-3");
        }
        {
            ulong input = 16777216UL;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "ulong-float-explicit-unchecked-variable-4");
        }
        {
            ulong input = 16777217UL;
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "ulong-float-explicit-unchecked-variable-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
