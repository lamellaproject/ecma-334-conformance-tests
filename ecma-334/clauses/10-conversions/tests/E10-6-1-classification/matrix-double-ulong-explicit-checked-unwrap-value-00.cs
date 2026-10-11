/*
Rules: E10-6-1-classification; E10-6-1-unwrap
Authority: ECMA-334 7th ed 10.6.1
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
            double? input = 0.0d;
            ulong result = checked((ulong)input);
            Check(result==0UL, "nullable-double-ulong-explicit-checked-unwrap-2");
        }
        {
            double? input = -0.0d;
            ulong result = checked((ulong)input);
            Check(result==0UL, "nullable-double-ulong-explicit-checked-unwrap-3");
        }
        {
            double? input = 1.0d;
            ulong result = checked((ulong)input);
            Check(result==1UL, "nullable-double-ulong-explicit-checked-unwrap-4");
        }
        {
            double? input = 0.75d;
            ulong result = checked((ulong)input);
            Check(result==0UL, "nullable-double-ulong-explicit-checked-unwrap-6");
        }
        {
            double? input = -0.75d;
            ulong result = checked((ulong)input);
            Check(result==0UL, "nullable-double-ulong-explicit-checked-unwrap-7");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
