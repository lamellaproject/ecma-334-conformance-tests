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
            int result = checked((int)input);
            Check(result==0, "nullable-ulong-int-explicit-checked-unwrap-0");
        }
        {
            ulong? input = 1UL;
            int result = checked((int)input);
            Check(result==1, "nullable-ulong-int-explicit-checked-unwrap-2");
        }
        {
            ulong? input = 2147483646UL;
            int result = checked((int)input);
            Check(result==2147483646, "nullable-ulong-int-explicit-checked-unwrap-3");
        }
        {
            ulong? input = 2147483647UL;
            int result = checked((int)input);
            Check(result==2147483647, "nullable-ulong-int-explicit-checked-unwrap-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
