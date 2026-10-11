/*
Rules: E10-3-2-all-pairs; E10-3-2-short; E12-23-numeric
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
            const short input = (short)(32767);
            ulong result = checked((ulong)input);
            Check(result==32767UL, "short-ulong-explicit-checked-constant-1");
        }
        {
            const short input = (short)(0);
            ulong result = checked((ulong)input);
            Check(result==0UL, "short-ulong-explicit-checked-constant-2");
        }
        {
            const short input = (short)(1);
            ulong result = checked((ulong)input);
            Check(result==1UL, "short-ulong-explicit-checked-constant-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
