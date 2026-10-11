/*
Rules: E10-3-2-all-pairs; E10-3-2-double; E12-23-numeric
Authority: ECMA-334 7th ed 10.3.2
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
            const double input = 0.0d;
            ulong result = checked((ulong)input);
            Check(result==0UL, "double-ulong-explicit-checked-constant-2");
        }
        {
            const double input = -0.0d;
            ulong result = checked((ulong)input);
            Check(result==0UL, "double-ulong-explicit-checked-constant-3");
        }
        {
            const double input = 1.0d;
            ulong result = checked((ulong)input);
            Check(result==1UL, "double-ulong-explicit-checked-constant-4");
        }
        {
            const double input = 0.75d;
            ulong result = checked((ulong)input);
            Check(result==0UL, "double-ulong-explicit-checked-constant-6");
        }
        {
            const double input = -0.75d;
            ulong result = checked((ulong)input);
            Check(result==0UL, "double-ulong-explicit-checked-constant-7");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
