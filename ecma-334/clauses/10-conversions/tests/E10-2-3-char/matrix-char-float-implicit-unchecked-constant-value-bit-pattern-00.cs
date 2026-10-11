/*
Rules: E10-2-3-char; E12-23-numeric
Authority: ECMA-334 7th ed 10.2.3
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
            const char input = (char)(0);
            float result = unchecked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==0U, "char-float-implicit-unchecked-constant-0");
        }
        {
            const char input = (char)(65535);
            float result = unchecked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1199570688U, "char-float-implicit-unchecked-constant-1");
        }
        {
            const char input = (char)(1);
            float result = unchecked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1065353216U, "char-float-implicit-unchecked-constant-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
