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
            long result = checked((long)input);
            Check(result==0L, "float-long-explicit-checked-variable-2");
        }
        {
            float input = -0.0f;
            long result = checked((long)input);
            Check(result==0L, "float-long-explicit-checked-variable-3");
        }
        {
            float input = 1.0f;
            long result = checked((long)input);
            Check(result==1L, "float-long-explicit-checked-variable-4");
        }
        {
            float input = -1.0f;
            long result = checked((long)input);
            Check(result==-1L, "float-long-explicit-checked-variable-5");
        }
        {
            float input = 0.75f;
            long result = checked((long)input);
            Check(result==0L, "float-long-explicit-checked-variable-6");
        }
        {
            float input = -0.75f;
            long result = checked((long)input);
            Check(result==0L, "float-long-explicit-checked-variable-7");
        }
        {
            float input = -9.22337204e+18f;
            long result = checked((long)input);
            Check(result==long.MinValue, "float-long-explicit-checked-variable-11");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
