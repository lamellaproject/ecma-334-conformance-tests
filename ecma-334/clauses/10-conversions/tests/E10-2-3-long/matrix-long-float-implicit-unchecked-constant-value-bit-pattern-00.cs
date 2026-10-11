/*
Rules: E10-2-3-long; E12-23-numeric
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
            const long input = long.MinValue;
            float result = unchecked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3741319168U, "long-float-implicit-unchecked-constant-0");
        }
        {
            const long input = 9223372036854775807L;
            float result = unchecked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1593835520U, "long-float-implicit-unchecked-constant-1");
        }
        {
            const long input = 0L;
            float result = unchecked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==0U, "long-float-implicit-unchecked-constant-2");
        }
        {
            const long input = 1L;
            float result = unchecked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1065353216U, "long-float-implicit-unchecked-constant-3");
        }
        {
            const long input = -1L;
            float result = unchecked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3212836864U, "long-float-implicit-unchecked-constant-4");
        }
        {
            const long input = 16777215L;
            float result = unchecked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679807U, "long-float-implicit-unchecked-constant-5");
        }
        {
            const long input = 16777216L;
            float result = unchecked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "long-float-implicit-unchecked-constant-6");
        }
        {
            const long input = 16777217L;
            float result = unchecked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "long-float-implicit-unchecked-constant-7");
        }
        {
            const long input = -16777217L;
            float result = unchecked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163456U, "long-float-implicit-unchecked-constant-8");
        }
        {
            const long input = -16777216L;
            float result = unchecked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163456U, "long-float-implicit-unchecked-constant-9");
        }
        {
            const long input = -16777215L;
            float result = unchecked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163455U, "long-float-implicit-unchecked-constant-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
