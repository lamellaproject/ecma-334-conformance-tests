/*
Rules: E10-6-1-classification; E10-6-1-unwrap
Authority: ECMA-334 7th ed 10.6.1
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
            ulong? input = 0UL;
            ulong result = unchecked((ulong)input);
            Check(result==0UL, "nullable-ulong-ulong-explicit-unchecked-unwrap-0");
        }
        {
            ulong? input = 18446744073709551615UL;
            ulong result = unchecked((ulong)input);
            Check(result==18446744073709551615UL, "nullable-ulong-ulong-explicit-unchecked-unwrap-1");
        }
        {
            ulong? input = 1UL;
            ulong result = unchecked((ulong)input);
            Check(result==1UL, "nullable-ulong-ulong-explicit-unchecked-unwrap-2");
        }
        {
            ulong? input = 18446744073709551614UL;
            ulong result = unchecked((ulong)input);
            Check(result==18446744073709551614UL, "nullable-ulong-ulong-explicit-unchecked-unwrap-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
