/*
Rules: E10-2-3-sbyte; E12-23-numeric
Authority: ECMA-334 7th ed 10.2.3
Version: 7.3
Expected: run
Stdout: OK 5
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
            const sbyte input = (sbyte)(-128);
            float result = unchecked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3271557120U, "sbyte-float-implicit-unchecked-constant-0");
        }
        {
            const sbyte input = (sbyte)(127);
            float result = unchecked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1123942400U, "sbyte-float-implicit-unchecked-constant-1");
        }
        {
            const sbyte input = (sbyte)(0);
            float result = unchecked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==0U, "sbyte-float-implicit-unchecked-constant-2");
        }
        {
            const sbyte input = (sbyte)(1);
            float result = unchecked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1065353216U, "sbyte-float-implicit-unchecked-constant-3");
        }
        {
            const sbyte input = (sbyte)(-1);
            float result = unchecked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3212836864U, "sbyte-float-implicit-unchecked-constant-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
