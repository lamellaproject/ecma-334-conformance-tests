/*
Rules: E10-3-2-all-pairs; E10-3-2-int
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
            int input = 2147483647;
            ulong result = checked((ulong)input);
            Check(result==2147483647UL, "int-ulong-explicit-checked-variable-1");
        }
        {
            int input = 0;
            ulong result = checked((ulong)input);
            Check(result==0UL, "int-ulong-explicit-checked-variable-2");
        }
        {
            int input = 1;
            ulong result = checked((ulong)input);
            Check(result==1UL, "int-ulong-explicit-checked-variable-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
