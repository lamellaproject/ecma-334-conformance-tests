/*
Rules: E10-3-2-all-pairs; E10-3-2-float
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 7
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
            float input = 0.0f;
            int result = unchecked((int)input);
            Check(result==0, "float-int-explicit-unchecked-variable-2");
        }
        {
            float input = -0.0f;
            int result = unchecked((int)input);
            Check(result==0, "float-int-explicit-unchecked-variable-3");
        }
        {
            float input = 1.0f;
            int result = unchecked((int)input);
            Check(result==1, "float-int-explicit-unchecked-variable-4");
        }
        {
            float input = -1.0f;
            int result = unchecked((int)input);
            Check(result==-1, "float-int-explicit-unchecked-variable-5");
        }
        {
            float input = 0.75f;
            int result = unchecked((int)input);
            Check(result==0, "float-int-explicit-unchecked-variable-6");
        }
        {
            float input = -0.75f;
            int result = unchecked((int)input);
            Check(result==0, "float-int-explicit-unchecked-variable-7");
        }
        {
            float input = -2.14748365e+09f;
            int result = unchecked((int)input);
            Check(result==-2147483648, "float-int-explicit-unchecked-variable-11");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
