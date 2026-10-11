/*
Rules: E10-3-2-all-pairs; E10-3-2-ulong
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 6
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
            ulong input = 0UL;
            long result = unchecked((long)input);
            Check(result==0L, "ulong-long-explicit-unchecked-variable-0");
        }
        {
            ulong input = 18446744073709551615UL;
            long result = unchecked((long)input);
            Check(result==-1L, "ulong-long-explicit-unchecked-variable-1");
        }
        {
            ulong input = 1UL;
            long result = unchecked((long)input);
            Check(result==1L, "ulong-long-explicit-unchecked-variable-2");
        }
        {
            ulong input = 9223372036854775806UL;
            long result = unchecked((long)input);
            Check(result==9223372036854775806L, "ulong-long-explicit-unchecked-variable-3");
        }
        {
            ulong input = 9223372036854775807UL;
            long result = unchecked((long)input);
            Check(result==9223372036854775807L, "ulong-long-explicit-unchecked-variable-4");
        }
        {
            ulong input = 9223372036854775808UL;
            long result = unchecked((long)input);
            Check(result==long.MinValue, "ulong-long-explicit-unchecked-variable-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
