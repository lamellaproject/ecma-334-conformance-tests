/*
Rules: E10-6-1-classification; E10-6-1-unwrap
Authority: ECMA-334 7th ed 10.6.1
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
            long? input = long.MinValue;
            long result = unchecked((long)input);
            Check(result==long.MinValue, "nullable-long-long-explicit-unchecked-unwrap-0");
        }
        {
            long? input = 9223372036854775807L;
            long result = unchecked((long)input);
            Check(result==9223372036854775807L, "nullable-long-long-explicit-unchecked-unwrap-1");
        }
        {
            long? input = 0L;
            long result = unchecked((long)input);
            Check(result==0L, "nullable-long-long-explicit-unchecked-unwrap-2");
        }
        {
            long? input = 1L;
            long result = unchecked((long)input);
            Check(result==1L, "nullable-long-long-explicit-unchecked-unwrap-3");
        }
        {
            long? input = -1L;
            long result = unchecked((long)input);
            Check(result==-1L, "nullable-long-long-explicit-unchecked-unwrap-4");
        }
        {
            long? input = -9223372036854775807L;
            long result = unchecked((long)input);
            Check(result==-9223372036854775807L, "nullable-long-long-explicit-unchecked-unwrap-5");
        }
        {
            long? input = 9223372036854775806L;
            long result = unchecked((long)input);
            Check(result==9223372036854775806L, "nullable-long-long-explicit-unchecked-unwrap-6");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
