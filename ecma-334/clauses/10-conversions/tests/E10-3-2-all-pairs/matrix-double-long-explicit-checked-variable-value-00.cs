/*
Rules: E10-3-2-all-pairs; E10-3-2-double
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
            double input = 0.0d;
            long result = checked((long)input);
            Check(result==0L, "double-long-explicit-checked-variable-2");
        }
        {
            double input = -0.0d;
            long result = checked((long)input);
            Check(result==0L, "double-long-explicit-checked-variable-3");
        }
        {
            double input = 1.0d;
            long result = checked((long)input);
            Check(result==1L, "double-long-explicit-checked-variable-4");
        }
        {
            double input = -1.0d;
            long result = checked((long)input);
            Check(result==-1L, "double-long-explicit-checked-variable-5");
        }
        {
            double input = 0.75d;
            long result = checked((long)input);
            Check(result==0L, "double-long-explicit-checked-variable-6");
        }
        {
            double input = -0.75d;
            long result = checked((long)input);
            Check(result==0L, "double-long-explicit-checked-variable-7");
        }
        {
            double input = -9.2233720368547758e+18d;
            long result = checked((long)input);
            Check(result==long.MinValue, "double-long-explicit-checked-variable-11");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
