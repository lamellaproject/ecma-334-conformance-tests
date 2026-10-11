/*
Rules: E10-3-2-all-pairs; E10-3-2-ulong; E12-23-numeric
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
            const ulong input = 0UL;
            long result = checked((long)input);
            Check(result==0L, "ulong-long-explicit-checked-constant-0");
        }
        {
            const ulong input = 1UL;
            long result = checked((long)input);
            Check(result==1L, "ulong-long-explicit-checked-constant-2");
        }
        {
            const ulong input = 9223372036854775806UL;
            long result = checked((long)input);
            Check(result==9223372036854775806L, "ulong-long-explicit-checked-constant-3");
        }
        {
            const ulong input = 9223372036854775807UL;
            long result = checked((long)input);
            Check(result==9223372036854775807L, "ulong-long-explicit-checked-constant-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
