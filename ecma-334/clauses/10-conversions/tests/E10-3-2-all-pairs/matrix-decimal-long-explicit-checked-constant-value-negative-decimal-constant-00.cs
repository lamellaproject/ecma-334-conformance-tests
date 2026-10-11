/*
Rules: E10-3-2-all-pairs; E10-3-2-decimal; E12-23-numeric
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 6
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
            const decimal input = -1m;
            long result = checked((long)input);
            Check(result==-1L, "decimal-long-explicit-checked-constant-4");
        }
        {
            const decimal input = -0.1m;
            long result = checked((long)input);
            Check(result==0L, "decimal-long-explicit-checked-constant-6");
        }
        {
            const decimal input = -1E-28m;
            long result = checked((long)input);
            Check(result==0L, "decimal-long-explicit-checked-constant-8");
        }
        {
            const decimal input = -9223372036854775808m;
            long result = checked((long)input);
            Check(result==long.MinValue, "decimal-long-explicit-checked-constant-10");
        }
        {
            const decimal input = -9223372036854775807m;
            long result = checked((long)input);
            Check(result==-9223372036854775807L, "decimal-long-explicit-checked-constant-11");
        }
        {
            const decimal input = -9223372036854775808.75m;
            long result = checked((long)input);
            Check(result==long.MinValue, "decimal-long-explicit-checked-constant-15");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
