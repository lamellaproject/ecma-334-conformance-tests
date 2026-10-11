/*
Rules: E10-3-2-all-pairs; E10-3-2-long
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 11
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
            short result = unchecked((short)input);
            Check(result==(short)(0), "long-short-explicit-unchecked-variable-0");
        }
        {
            long input = 9223372036854775807L;
            short result = unchecked((short)input);
            Check(result==(short)(-1), "long-short-explicit-unchecked-variable-1");
        }
        {
            long input = 0L;
            short result = unchecked((short)input);
            Check(result==(short)(0), "long-short-explicit-unchecked-variable-2");
        }
        {
            long input = 1L;
            short result = unchecked((short)input);
            Check(result==(short)(1), "long-short-explicit-unchecked-variable-3");
        }
        {
            long input = -1L;
            short result = unchecked((short)input);
            Check(result==(short)(-1), "long-short-explicit-unchecked-variable-4");
        }
        {
            long input = -32769L;
            short result = unchecked((short)input);
            Check(result==(short)(32767), "long-short-explicit-unchecked-variable-5");
        }
        {
            long input = -32768L;
            short result = unchecked((short)input);
            Check(result==(short)(-32768), "long-short-explicit-unchecked-variable-6");
        }
        {
            long input = -32767L;
            short result = unchecked((short)input);
            Check(result==(short)(-32767), "long-short-explicit-unchecked-variable-7");
        }
        {
            long input = 32766L;
            short result = unchecked((short)input);
            Check(result==(short)(32766), "long-short-explicit-unchecked-variable-8");
        }
        {
            long input = 32767L;
            short result = unchecked((short)input);
            Check(result==(short)(32767), "long-short-explicit-unchecked-variable-9");
        }
        {
            long input = 32768L;
            short result = unchecked((short)input);
            Check(result==(short)(-32768), "long-short-explicit-unchecked-variable-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
