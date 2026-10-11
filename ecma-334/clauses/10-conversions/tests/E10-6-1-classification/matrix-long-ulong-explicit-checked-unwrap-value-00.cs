/*
Rules: E10-6-1-classification; E10-6-1-unwrap
Authority: ECMA-334 7th ed 10.6.1
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
            long? input = 9223372036854775807L;
            ulong result = checked((ulong)input);
            Check(result==9223372036854775807UL, "nullable-long-ulong-explicit-checked-unwrap-1");
        }
        {
            long? input = 0L;
            ulong result = checked((ulong)input);
            Check(result==0UL, "nullable-long-ulong-explicit-checked-unwrap-2");
        }
        {
            long? input = 1L;
            ulong result = checked((ulong)input);
            Check(result==1UL, "nullable-long-ulong-explicit-checked-unwrap-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
