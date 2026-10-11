/*
Rules: E10-3-2-all-pairs; E10-3-2-long; E12-23-numeric
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
            const long input = long.MinValue;
            short result = unchecked((short)input);
            Check(result==(short)(0), "long-short-explicit-unchecked-constant-0");
        }
        {
            const long input = 9223372036854775807L;
            short result = unchecked((short)input);
            Check(result==(short)(-1), "long-short-explicit-unchecked-constant-1");
        }
        {
            const long input = 0L;
            short result = unchecked((short)input);
            Check(result==(short)(0), "long-short-explicit-unchecked-constant-2");
        }
        {
            const long input = 1L;
            short result = unchecked((short)input);
            Check(result==(short)(1), "long-short-explicit-unchecked-constant-3");
        }
        {
            const long input = -1L;
            short result = unchecked((short)input);
            Check(result==(short)(-1), "long-short-explicit-unchecked-constant-4");
        }
        {
            const long input = -32769L;
            short result = unchecked((short)input);
            Check(result==(short)(32767), "long-short-explicit-unchecked-constant-5");
        }
        {
            const long input = -32768L;
            short result = unchecked((short)input);
            Check(result==(short)(-32768), "long-short-explicit-unchecked-constant-6");
        }
        {
            const long input = -32767L;
            short result = unchecked((short)input);
            Check(result==(short)(-32767), "long-short-explicit-unchecked-constant-7");
        }
        {
            const long input = 32766L;
            short result = unchecked((short)input);
            Check(result==(short)(32766), "long-short-explicit-unchecked-constant-8");
        }
        {
            const long input = 32767L;
            short result = unchecked((short)input);
            Check(result==(short)(32767), "long-short-explicit-unchecked-constant-9");
        }
        {
            const long input = 32768L;
            short result = unchecked((short)input);
            Check(result==(short)(-32768), "long-short-explicit-unchecked-constant-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
