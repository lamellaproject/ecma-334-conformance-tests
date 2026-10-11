/*
Rules: E10-6-1-classification; E10-6-1-unwrap
Authority: ECMA-334 7th ed 10.6.1
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
            double? input = 0.0d;
            short result = checked((short)input);
            Check(result==(short)(0), "nullable-double-short-explicit-checked-unwrap-2");
        }
        {
            double? input = -0.0d;
            short result = checked((short)input);
            Check(result==(short)(0), "nullable-double-short-explicit-checked-unwrap-3");
        }
        {
            double? input = 1.0d;
            short result = checked((short)input);
            Check(result==(short)(1), "nullable-double-short-explicit-checked-unwrap-4");
        }
        {
            double? input = -1.0d;
            short result = checked((short)input);
            Check(result==(short)(-1), "nullable-double-short-explicit-checked-unwrap-5");
        }
        {
            double? input = 0.75d;
            short result = checked((short)input);
            Check(result==(short)(0), "nullable-double-short-explicit-checked-unwrap-6");
        }
        {
            double? input = -0.75d;
            short result = checked((short)input);
            Check(result==(short)(0), "nullable-double-short-explicit-checked-unwrap-7");
        }
        {
            double? input = -32768.0d;
            short result = checked((short)input);
            Check(result==(short)(-32768), "nullable-double-short-explicit-checked-unwrap-12");
        }
        {
            double? input = -32767.0d;
            short result = checked((short)input);
            Check(result==(short)(-32767), "nullable-double-short-explicit-checked-unwrap-13");
        }
        {
            double? input = 32766.0d;
            short result = checked((short)input);
            Check(result==(short)(32766), "nullable-double-short-explicit-checked-unwrap-14");
        }
        {
            double? input = 32767.0d;
            short result = checked((short)input);
            Check(result==(short)(32767), "nullable-double-short-explicit-checked-unwrap-15");
        }
        {
            double? input = -32768.75d;
            short result = checked((short)input);
            Check(result==(short)(-32768), "nullable-double-short-explicit-checked-unwrap-17");
        }
        {
            double? input = 32767.75d;
            short result = checked((short)input);
            Check(result==(short)(32767), "nullable-double-short-explicit-checked-unwrap-18");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
