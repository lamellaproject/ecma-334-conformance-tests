/*
Rules: E10-3-2-all-pairs; E10-3-2-ulong
Authority: ECMA-334 7th ed 10.3.2
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
            int result = checked((int)input);
            Check(result==0, "ulong-int-explicit-checked-variable-0");
        }
        {
            ulong input = 1UL;
            int result = checked((int)input);
            Check(result==1, "ulong-int-explicit-checked-variable-2");
        }
        {
            ulong input = 2147483646UL;
            int result = checked((int)input);
            Check(result==2147483646, "ulong-int-explicit-checked-variable-3");
        }
        {
            ulong input = 2147483647UL;
            int result = checked((int)input);
            Check(result==2147483647, "ulong-int-explicit-checked-variable-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
