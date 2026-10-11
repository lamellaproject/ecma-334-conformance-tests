/*
Rules: E10-2-11-long; E12-23-numeric
Authority: ECMA-334 7th ed 10.2.11
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
            ulong result = checked(input);
            Check(result==9223372036854775807UL, "long-ulong-implicit-checked-constant-1");
        }
        {
            const long input = 0L;
            ulong result = checked(input);
            Check(result==0UL, "long-ulong-implicit-checked-constant-2");
        }
        {
            const long input = 1L;
            ulong result = checked(input);
            Check(result==1UL, "long-ulong-implicit-checked-constant-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
