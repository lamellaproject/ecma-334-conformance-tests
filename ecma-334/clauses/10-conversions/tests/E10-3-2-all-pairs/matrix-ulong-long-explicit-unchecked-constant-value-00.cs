/*
Rules: E10-3-2-all-pairs; E10-3-2-ulong; E12-23-numeric
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
            const ulong input = 0UL;
            long result = unchecked((long)input);
            Check(result==0L, "ulong-long-explicit-unchecked-constant-0");
        }
        {
            const ulong input = 18446744073709551615UL;
            long result = unchecked((long)input);
            Check(result==-1L, "ulong-long-explicit-unchecked-constant-1");
        }
        {
            const ulong input = 1UL;
            long result = unchecked((long)input);
            Check(result==1L, "ulong-long-explicit-unchecked-constant-2");
        }
        {
            const ulong input = 9223372036854775806UL;
            long result = unchecked((long)input);
            Check(result==9223372036854775806L, "ulong-long-explicit-unchecked-constant-3");
        }
        {
            const ulong input = 9223372036854775807UL;
            long result = unchecked((long)input);
            Check(result==9223372036854775807L, "ulong-long-explicit-unchecked-constant-4");
        }
        {
            const ulong input = 9223372036854775808UL;
            long result = unchecked((long)input);
            Check(result==long.MinValue, "ulong-long-explicit-unchecked-constant-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
