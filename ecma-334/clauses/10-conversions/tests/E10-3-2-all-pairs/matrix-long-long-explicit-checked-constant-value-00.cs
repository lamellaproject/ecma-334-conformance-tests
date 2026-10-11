/*
Rules: E10-3-2-all-pairs; E12-23-numeric
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 7
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
            const long input = long.MinValue;
            long result = checked((long)input);
            Check(result==long.MinValue, "long-long-explicit-checked-constant-0");
        }
        {
            const long input = 9223372036854775807L;
            long result = checked((long)input);
            Check(result==9223372036854775807L, "long-long-explicit-checked-constant-1");
        }
        {
            const long input = 0L;
            long result = checked((long)input);
            Check(result==0L, "long-long-explicit-checked-constant-2");
        }
        {
            const long input = 1L;
            long result = checked((long)input);
            Check(result==1L, "long-long-explicit-checked-constant-3");
        }
        {
            const long input = -1L;
            long result = checked((long)input);
            Check(result==-1L, "long-long-explicit-checked-constant-4");
        }
        {
            const long input = -9223372036854775807L;
            long result = checked((long)input);
            Check(result==-9223372036854775807L, "long-long-explicit-checked-constant-5");
        }
        {
            const long input = 9223372036854775806L;
            long result = checked((long)input);
            Check(result==9223372036854775806L, "long-long-explicit-checked-constant-6");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
