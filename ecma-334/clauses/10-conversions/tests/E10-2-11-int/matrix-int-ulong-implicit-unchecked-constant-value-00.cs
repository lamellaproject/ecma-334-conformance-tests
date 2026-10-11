/*
Rules: E10-2-11-int; E12-23-numeric
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
            const int input = 2147483647;
            ulong result = unchecked(input);
            Check(result==2147483647UL, "int-ulong-implicit-unchecked-constant-1");
        }
        {
            const int input = 0;
            ulong result = unchecked(input);
            Check(result==0UL, "int-ulong-implicit-unchecked-constant-2");
        }
        {
            const int input = 1;
            ulong result = unchecked(input);
            Check(result==1UL, "int-ulong-implicit-unchecked-constant-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
