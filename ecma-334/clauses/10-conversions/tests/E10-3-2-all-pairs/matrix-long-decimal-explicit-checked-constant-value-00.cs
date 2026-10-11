/*
Rules: E10-3-2-all-pairs; E10-3-2-long; E12-23-numeric
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
            const long input = long.MinValue;
            decimal result = checked((decimal)input);
            Check(result==-9223372036854775808m, "long-decimal-explicit-checked-constant-0");
        }
        {
            const long input = 9223372036854775807L;
            decimal result = checked((decimal)input);
            Check(result==9223372036854775807m, "long-decimal-explicit-checked-constant-1");
        }
        {
            const long input = 0L;
            decimal result = checked((decimal)input);
            Check(result==0m, "long-decimal-explicit-checked-constant-2");
        }
        {
            const long input = 1L;
            decimal result = checked((decimal)input);
            Check(result==1m, "long-decimal-explicit-checked-constant-3");
        }
        {
            const long input = -1L;
            decimal result = checked((decimal)input);
            Check(result==-1m, "long-decimal-explicit-checked-constant-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
