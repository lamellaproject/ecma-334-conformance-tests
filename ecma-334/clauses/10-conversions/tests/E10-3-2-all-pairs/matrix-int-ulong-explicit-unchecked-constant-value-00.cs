/*
Rules: E10-3-2-all-pairs; E10-3-2-int; E12-23-numeric
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
            const int input = -2147483648;
            ulong result = unchecked((ulong)input);
            Check(result==18446744071562067968UL, "int-ulong-explicit-unchecked-constant-0");
        }
        {
            const int input = 2147483647;
            ulong result = unchecked((ulong)input);
            Check(result==2147483647UL, "int-ulong-explicit-unchecked-constant-1");
        }
        {
            const int input = 0;
            ulong result = unchecked((ulong)input);
            Check(result==0UL, "int-ulong-explicit-unchecked-constant-2");
        }
        {
            const int input = 1;
            ulong result = unchecked((ulong)input);
            Check(result==1UL, "int-ulong-explicit-unchecked-constant-3");
        }
        {
            const int input = -1;
            ulong result = unchecked((ulong)input);
            Check(result==18446744073709551615UL, "int-ulong-explicit-unchecked-constant-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
