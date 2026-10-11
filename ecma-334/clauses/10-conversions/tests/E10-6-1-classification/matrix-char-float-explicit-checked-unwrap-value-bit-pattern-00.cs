/*
Rules: E10-6-1-classification; E10-6-1-unwrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 3
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
            char? input = (char)(0);
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==0U, "nullable-char-float-explicit-checked-unwrap-0");
        }
        {
            char? input = (char)(65535);
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1199570688U, "nullable-char-float-explicit-checked-unwrap-1");
        }
        {
            char? input = (char)(1);
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1065353216U, "nullable-char-float-explicit-checked-unwrap-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
