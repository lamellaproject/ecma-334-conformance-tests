/*
Rules: E10-2-2-same
Authority: ECMA-334 7th ed 10.2.2
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
            ulong input = 0UL;
            ulong result = unchecked(input);
            Check(result==0UL, "ulong-ulong-implicit-unchecked-variable-0");
        }
        {
            ulong input = 18446744073709551615UL;
            ulong result = unchecked(input);
            Check(result==18446744073709551615UL, "ulong-ulong-implicit-unchecked-variable-1");
        }
        {
            ulong input = 1UL;
            ulong result = unchecked(input);
            Check(result==1UL, "ulong-ulong-implicit-unchecked-variable-2");
        }
        {
            ulong input = 18446744073709551614UL;
            ulong result = unchecked(input);
            Check(result==18446744073709551614UL, "ulong-ulong-implicit-unchecked-variable-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
