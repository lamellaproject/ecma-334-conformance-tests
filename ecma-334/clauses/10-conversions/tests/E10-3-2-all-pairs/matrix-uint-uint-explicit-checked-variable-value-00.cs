/*
Rules: E10-3-2-all-pairs
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
            uint input = 0U;
            uint result = checked((uint)input);
            Check(result==0U, "uint-uint-explicit-checked-variable-0");
        }
        {
            uint input = 4294967295U;
            uint result = checked((uint)input);
            Check(result==4294967295U, "uint-uint-explicit-checked-variable-1");
        }
        {
            uint input = 1U;
            uint result = checked((uint)input);
            Check(result==1U, "uint-uint-explicit-checked-variable-2");
        }
        {
            uint input = 4294967294U;
            uint result = checked((uint)input);
            Check(result==4294967294U, "uint-uint-explicit-checked-variable-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
