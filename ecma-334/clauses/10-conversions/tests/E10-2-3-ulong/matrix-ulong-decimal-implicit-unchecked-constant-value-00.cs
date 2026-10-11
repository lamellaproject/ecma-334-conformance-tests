/*
Rules: E10-2-3-ulong; E12-23-numeric
Authority: ECMA-334 7th ed 10.2.3
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
            const ulong input = 0UL;
            decimal result = unchecked(input);
            Check(result==0m, "ulong-decimal-implicit-unchecked-constant-0");
        }
        {
            const ulong input = 18446744073709551615UL;
            decimal result = unchecked(input);
            Check(result==18446744073709551615m, "ulong-decimal-implicit-unchecked-constant-1");
        }
        {
            const ulong input = 1UL;
            decimal result = unchecked(input);
            Check(result==1m, "ulong-decimal-implicit-unchecked-constant-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
