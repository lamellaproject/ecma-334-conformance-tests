/*
Rules: E10-3-2-all-pairs; E10-3-2-uint; E12-23-numeric
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
            const uint input = 0U;
            ulong result = checked((ulong)input);
            Check(result==0UL, "uint-ulong-explicit-checked-constant-0");
        }
        {
            const uint input = 4294967295U;
            ulong result = checked((ulong)input);
            Check(result==4294967295UL, "uint-ulong-explicit-checked-constant-1");
        }
        {
            const uint input = 1U;
            ulong result = checked((ulong)input);
            Check(result==1UL, "uint-ulong-explicit-checked-constant-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
