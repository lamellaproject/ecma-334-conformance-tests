/*
Rules: E10-3-2-all-pairs; E10-3-2-long
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
            long input = long.MinValue;
            decimal result = unchecked((decimal)input);
            Check(result==-9223372036854775808m, "long-decimal-explicit-unchecked-variable-0");
        }
        {
            long input = 9223372036854775807L;
            decimal result = unchecked((decimal)input);
            Check(result==9223372036854775807m, "long-decimal-explicit-unchecked-variable-1");
        }
        {
            long input = 0L;
            decimal result = unchecked((decimal)input);
            Check(result==0m, "long-decimal-explicit-unchecked-variable-2");
        }
        {
            long input = 1L;
            decimal result = unchecked((decimal)input);
            Check(result==1m, "long-decimal-explicit-unchecked-variable-3");
        }
        {
            long input = -1L;
            decimal result = unchecked((decimal)input);
            Check(result==-1m, "long-decimal-explicit-unchecked-variable-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
