/*
Rules: E10-2-2-same; E12-23-numeric
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
            const ulong input = 0UL;
            ulong result = checked(input);
            Check(result==0UL, "ulong-ulong-implicit-checked-constant-0");
        }
        {
            const ulong input = 18446744073709551615UL;
            ulong result = checked(input);
            Check(result==18446744073709551615UL, "ulong-ulong-implicit-checked-constant-1");
        }
        {
            const ulong input = 1UL;
            ulong result = checked(input);
            Check(result==1UL, "ulong-ulong-implicit-checked-constant-2");
        }
        {
            const ulong input = 18446744073709551614UL;
            ulong result = checked(input);
            Check(result==18446744073709551614UL, "ulong-ulong-implicit-checked-constant-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
