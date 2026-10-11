/*
Rules: E10-2-3-short
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
            short input = (short)(-32768);
            float result = unchecked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3338665984U, "short-float-implicit-unchecked-variable-0");
        }
        {
            short input = (short)(32767);
            float result = unchecked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1191181824U, "short-float-implicit-unchecked-variable-1");
        }
        {
            short input = (short)(0);
            float result = unchecked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==0U, "short-float-implicit-unchecked-variable-2");
        }
        {
            short input = (short)(1);
            float result = unchecked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1065353216U, "short-float-implicit-unchecked-variable-3");
        }
        {
            short input = (short)(-1);
            float result = unchecked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3212836864U, "short-float-implicit-unchecked-variable-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
