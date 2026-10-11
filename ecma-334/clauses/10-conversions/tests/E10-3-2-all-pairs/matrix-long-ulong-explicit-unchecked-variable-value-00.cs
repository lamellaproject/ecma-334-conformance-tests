/*
Rules: E10-3-2-all-pairs; E10-3-2-long
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
            long input = long.MinValue;
            ulong result = unchecked((ulong)input);
            Check(result==9223372036854775808UL, "long-ulong-explicit-unchecked-variable-0");
        }
        {
            long input = 9223372036854775807L;
            ulong result = unchecked((ulong)input);
            Check(result==9223372036854775807UL, "long-ulong-explicit-unchecked-variable-1");
        }
        {
            long input = 0L;
            ulong result = unchecked((ulong)input);
            Check(result==0UL, "long-ulong-explicit-unchecked-variable-2");
        }
        {
            long input = 1L;
            ulong result = unchecked((ulong)input);
            Check(result==1UL, "long-ulong-explicit-unchecked-variable-3");
        }
        {
            long input = -1L;
            ulong result = unchecked((ulong)input);
            Check(result==18446744073709551615UL, "long-ulong-explicit-unchecked-variable-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
