/*
Rules: E10-3-2-all-pairs; E10-3-2-float
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
            float input = 0.0f;
            short result = checked((short)input);
            Check(result==(short)(0), "float-short-explicit-checked-variable-2");
        }
        {
            float input = -0.0f;
            short result = checked((short)input);
            Check(result==(short)(0), "float-short-explicit-checked-variable-3");
        }
        {
            float input = 1.0f;
            short result = checked((short)input);
            Check(result==(short)(1), "float-short-explicit-checked-variable-4");
        }
        {
            float input = -1.0f;
            short result = checked((short)input);
            Check(result==(short)(-1), "float-short-explicit-checked-variable-5");
        }
        {
            float input = 0.75f;
            short result = checked((short)input);
            Check(result==(short)(0), "float-short-explicit-checked-variable-6");
        }
        {
            float input = -0.75f;
            short result = checked((short)input);
            Check(result==(short)(0), "float-short-explicit-checked-variable-7");
        }
        {
            float input = -32768.0f;
            short result = checked((short)input);
            Check(result==(short)(-32768), "float-short-explicit-checked-variable-12");
        }
        {
            float input = -32767.0f;
            short result = checked((short)input);
            Check(result==(short)(-32767), "float-short-explicit-checked-variable-13");
        }
        {
            float input = 32766.0f;
            short result = checked((short)input);
            Check(result==(short)(32766), "float-short-explicit-checked-variable-14");
        }
        {
            float input = 32767.0f;
            short result = checked((short)input);
            Check(result==(short)(32767), "float-short-explicit-checked-variable-15");
        }
        {
            float input = -32768.75f;
            short result = checked((short)input);
            Check(result==(short)(-32768), "float-short-explicit-checked-variable-17");
        }
        {
            float input = 32767.75f;
            short result = checked((short)input);
            Check(result==(short)(32767), "float-short-explicit-checked-variable-18");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
