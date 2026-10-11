/*
Rules: E10-3-2-all-pairs; E10-3-2-float; E12-23-numeric
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
            const float input = 0.0f;
            int result = checked((int)input);
            Check(result==0, "float-int-explicit-checked-constant-2");
        }
        {
            const float input = -0.0f;
            int result = checked((int)input);
            Check(result==0, "float-int-explicit-checked-constant-3");
        }
        {
            const float input = 1.0f;
            int result = checked((int)input);
            Check(result==1, "float-int-explicit-checked-constant-4");
        }
        {
            const float input = -1.0f;
            int result = checked((int)input);
            Check(result==-1, "float-int-explicit-checked-constant-5");
        }
        {
            const float input = 0.75f;
            int result = checked((int)input);
            Check(result==0, "float-int-explicit-checked-constant-6");
        }
        {
            const float input = -0.75f;
            int result = checked((int)input);
            Check(result==0, "float-int-explicit-checked-constant-7");
        }
        {
            const float input = -2.14748365e+09f;
            int result = checked((int)input);
            Check(result==-2147483648, "float-int-explicit-checked-constant-11");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
