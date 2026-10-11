/*
Rules: E10-3-2-all-pairs; E10-3-2-double
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 12
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
            double input = 0.0d;
            short result = checked((short)input);
            Check(result==(short)(0), "double-short-explicit-checked-variable-2");
        }
        {
            double input = -0.0d;
            short result = checked((short)input);
            Check(result==(short)(0), "double-short-explicit-checked-variable-3");
        }
        {
            double input = 1.0d;
            short result = checked((short)input);
            Check(result==(short)(1), "double-short-explicit-checked-variable-4");
        }
        {
            double input = -1.0d;
            short result = checked((short)input);
            Check(result==(short)(-1), "double-short-explicit-checked-variable-5");
        }
        {
            double input = 0.75d;
            short result = checked((short)input);
            Check(result==(short)(0), "double-short-explicit-checked-variable-6");
        }
        {
            double input = -0.75d;
            short result = checked((short)input);
            Check(result==(short)(0), "double-short-explicit-checked-variable-7");
        }
        {
            double input = -32768.0d;
            short result = checked((short)input);
            Check(result==(short)(-32768), "double-short-explicit-checked-variable-12");
        }
        {
            double input = -32767.0d;
            short result = checked((short)input);
            Check(result==(short)(-32767), "double-short-explicit-checked-variable-13");
        }
        {
            double input = 32766.0d;
            short result = checked((short)input);
            Check(result==(short)(32766), "double-short-explicit-checked-variable-14");
        }
        {
            double input = 32767.0d;
            short result = checked((short)input);
            Check(result==(short)(32767), "double-short-explicit-checked-variable-15");
        }
        {
            double input = -32768.75d;
            short result = checked((short)input);
            Check(result==(short)(-32768), "double-short-explicit-checked-variable-17");
        }
        {
            double input = 32767.75d;
            short result = checked((short)input);
            Check(result==(short)(32767), "double-short-explicit-checked-variable-18");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
