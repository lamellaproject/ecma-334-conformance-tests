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
            short input = (short)(-32768);
            short result = checked((short)input);
            Check(result==(short)(-32768), "short-short-explicit-checked-variable-0");
        }
        {
            short input = (short)(32767);
            short result = checked((short)input);
            Check(result==(short)(32767), "short-short-explicit-checked-variable-1");
        }
        {
            short input = (short)(0);
            short result = checked((short)input);
            Check(result==(short)(0), "short-short-explicit-checked-variable-2");
        }
        {
            short input = (short)(1);
            short result = checked((short)input);
            Check(result==(short)(1), "short-short-explicit-checked-variable-3");
        }
        {
            short input = (short)(-1);
            short result = checked((short)input);
            Check(result==(short)(-1), "short-short-explicit-checked-variable-4");
        }
        {
            short input = (short)(-32767);
            short result = checked((short)input);
            Check(result==(short)(-32767), "short-short-explicit-checked-variable-5");
        }
        {
            short input = (short)(32766);
            short result = checked((short)input);
            Check(result==(short)(32766), "short-short-explicit-checked-variable-6");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
