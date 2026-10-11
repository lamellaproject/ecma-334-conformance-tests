/*
Rules: E10-3-2-all-pairs; E10-3-2-long; E12-23-numeric
Authority: ECMA-334 7th ed 10.3.2
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
            const long input = 9223372036854775807L;
            ulong result = checked((ulong)input);
            Check(result==9223372036854775807UL, "long-ulong-explicit-checked-constant-1");
        }
        {
            const long input = 0L;
            ulong result = checked((ulong)input);
            Check(result==0UL, "long-ulong-explicit-checked-constant-2");
        }
        {
            const long input = 1L;
            ulong result = checked((ulong)input);
            Check(result==1UL, "long-ulong-explicit-checked-constant-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
