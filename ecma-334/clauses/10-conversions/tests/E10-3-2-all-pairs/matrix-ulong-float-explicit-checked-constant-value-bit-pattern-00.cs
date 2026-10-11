/*
Rules: E10-3-2-all-pairs; E10-3-2-ulong; E12-23-numeric
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
            const ulong input = 0UL;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==0U, "ulong-float-explicit-checked-constant-0");
        }
        {
            const ulong input = 18446744073709551615UL;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1602224128U, "ulong-float-explicit-checked-constant-1");
        }
        {
            const ulong input = 1UL;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1065353216U, "ulong-float-explicit-checked-constant-2");
        }
        {
            const ulong input = 16777215UL;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679807U, "ulong-float-explicit-checked-constant-3");
        }
        {
            const ulong input = 16777216UL;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "ulong-float-explicit-checked-constant-4");
        }
        {
            const ulong input = 16777217UL;
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "ulong-float-explicit-checked-constant-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
