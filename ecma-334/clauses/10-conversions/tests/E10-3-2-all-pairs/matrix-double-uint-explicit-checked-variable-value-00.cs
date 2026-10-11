/*
Rules: E10-3-2-all-pairs; E10-3-2-double
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 8
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
            uint result = checked((uint)input);
            Check(result==0U, "double-uint-explicit-checked-variable-2");
        }
        {
            double input = -0.0d;
            uint result = checked((uint)input);
            Check(result==0U, "double-uint-explicit-checked-variable-3");
        }
        {
            double input = 1.0d;
            uint result = checked((uint)input);
            Check(result==1U, "double-uint-explicit-checked-variable-4");
        }
        {
            double input = 0.75d;
            uint result = checked((uint)input);
            Check(result==0U, "double-uint-explicit-checked-variable-6");
        }
        {
            double input = -0.75d;
            uint result = checked((uint)input);
            Check(result==0U, "double-uint-explicit-checked-variable-7");
        }
        {
            double input = 4294967294.0d;
            uint result = checked((uint)input);
            Check(result==4294967294U, "double-uint-explicit-checked-variable-11");
        }
        {
            double input = 4294967295.0d;
            uint result = checked((uint)input);
            Check(result==4294967295U, "double-uint-explicit-checked-variable-12");
        }
        {
            double input = 4294967295.75d;
            uint result = checked((uint)input);
            Check(result==4294967295U, "double-uint-explicit-checked-variable-14");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
