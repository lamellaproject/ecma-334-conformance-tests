/*
Rules: E10-3-2-all-pairs; E10-3-2-ulong
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
            ulong input = 0UL;
            decimal result = unchecked((decimal)input);
            Check(result==0m, "ulong-decimal-explicit-unchecked-variable-0");
        }
        {
            ulong input = 18446744073709551615UL;
            decimal result = unchecked((decimal)input);
            Check(result==18446744073709551615m, "ulong-decimal-explicit-unchecked-variable-1");
        }
        {
            ulong input = 1UL;
            decimal result = unchecked((decimal)input);
            Check(result==1m, "ulong-decimal-explicit-unchecked-variable-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
