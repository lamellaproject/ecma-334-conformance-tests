/*
Rules: E10-3-2-all-pairs; E10-3-2-decimal
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 13
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
            decimal input = 0m;
            long result = checked((long)input);
            Check(result==0L, "decimal-long-explicit-checked-variable-2");
        }
        {
            decimal input = 1m;
            long result = checked((long)input);
            Check(result==1L, "decimal-long-explicit-checked-variable-3");
        }
        {
            decimal input = -1m;
            long result = checked((long)input);
            Check(result==-1L, "decimal-long-explicit-checked-variable-4");
        }
        {
            decimal input = 0.1m;
            long result = checked((long)input);
            Check(result==0L, "decimal-long-explicit-checked-variable-5");
        }
        {
            decimal input = -0.1m;
            long result = checked((long)input);
            Check(result==0L, "decimal-long-explicit-checked-variable-6");
        }
        {
            decimal input = 1E-28m;
            long result = checked((long)input);
            Check(result==0L, "decimal-long-explicit-checked-variable-7");
        }
        {
            decimal input = -1E-28m;
            long result = checked((long)input);
            Check(result==0L, "decimal-long-explicit-checked-variable-8");
        }
        {
            decimal input = -9223372036854775808m;
            long result = checked((long)input);
            Check(result==long.MinValue, "decimal-long-explicit-checked-variable-10");
        }
        {
            decimal input = -9223372036854775807m;
            long result = checked((long)input);
            Check(result==-9223372036854775807L, "decimal-long-explicit-checked-variable-11");
        }
        {
            decimal input = 9223372036854775806m;
            long result = checked((long)input);
            Check(result==9223372036854775806L, "decimal-long-explicit-checked-variable-12");
        }
        {
            decimal input = 9223372036854775807m;
            long result = checked((long)input);
            Check(result==9223372036854775807L, "decimal-long-explicit-checked-variable-13");
        }
        {
            decimal input = -9223372036854775808.75m;
            long result = checked((long)input);
            Check(result==long.MinValue, "decimal-long-explicit-checked-variable-15");
        }
        {
            decimal input = 9223372036854775807.75m;
            long result = checked((long)input);
            Check(result==9223372036854775807L, "decimal-long-explicit-checked-variable-16");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
