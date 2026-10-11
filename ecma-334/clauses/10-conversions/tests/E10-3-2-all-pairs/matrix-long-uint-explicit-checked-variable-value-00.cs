/*
Rules: E10-3-2-all-pairs; E10-3-2-long
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 4
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
            long input = 0L;
            uint result = checked((uint)input);
            Check(result==0U, "long-uint-explicit-checked-variable-2");
        }
        {
            long input = 1L;
            uint result = checked((uint)input);
            Check(result==1U, "long-uint-explicit-checked-variable-3");
        }
        {
            long input = 4294967294L;
            uint result = checked((uint)input);
            Check(result==4294967294U, "long-uint-explicit-checked-variable-5");
        }
        {
            long input = 4294967295L;
            uint result = checked((uint)input);
            Check(result==4294967295U, "long-uint-explicit-checked-variable-6");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
