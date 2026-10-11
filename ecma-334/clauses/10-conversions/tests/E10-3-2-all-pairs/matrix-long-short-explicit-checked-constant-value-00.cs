/*
Rules: E10-3-2-all-pairs; E10-3-2-long; E12-23-numeric
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
            const long input = 0L;
            short result = checked((short)input);
            Check(result==(short)(0), "long-short-explicit-checked-constant-2");
        }
        {
            const long input = 1L;
            short result = checked((short)input);
            Check(result==(short)(1), "long-short-explicit-checked-constant-3");
        }
        {
            const long input = -1L;
            short result = checked((short)input);
            Check(result==(short)(-1), "long-short-explicit-checked-constant-4");
        }
        {
            const long input = -32768L;
            short result = checked((short)input);
            Check(result==(short)(-32768), "long-short-explicit-checked-constant-6");
        }
        {
            const long input = -32767L;
            short result = checked((short)input);
            Check(result==(short)(-32767), "long-short-explicit-checked-constant-7");
        }
        {
            const long input = 32766L;
            short result = checked((short)input);
            Check(result==(short)(32766), "long-short-explicit-checked-constant-8");
        }
        {
            const long input = 32767L;
            short result = checked((short)input);
            Check(result==(short)(32767), "long-short-explicit-checked-constant-9");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
