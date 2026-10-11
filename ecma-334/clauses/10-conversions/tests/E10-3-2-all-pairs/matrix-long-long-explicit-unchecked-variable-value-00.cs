/*
Rules: E10-3-2-all-pairs
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
            long input = long.MinValue;
            long result = unchecked((long)input);
            Check(result==long.MinValue, "long-long-explicit-unchecked-variable-0");
        }
        {
            long input = 9223372036854775807L;
            long result = unchecked((long)input);
            Check(result==9223372036854775807L, "long-long-explicit-unchecked-variable-1");
        }
        {
            long input = 0L;
            long result = unchecked((long)input);
            Check(result==0L, "long-long-explicit-unchecked-variable-2");
        }
        {
            long input = 1L;
            long result = unchecked((long)input);
            Check(result==1L, "long-long-explicit-unchecked-variable-3");
        }
        {
            long input = -1L;
            long result = unchecked((long)input);
            Check(result==-1L, "long-long-explicit-unchecked-variable-4");
        }
        {
            long input = -9223372036854775807L;
            long result = unchecked((long)input);
            Check(result==-9223372036854775807L, "long-long-explicit-unchecked-variable-5");
        }
        {
            long input = 9223372036854775806L;
            long result = unchecked((long)input);
            Check(result==9223372036854775806L, "long-long-explicit-unchecked-variable-6");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
