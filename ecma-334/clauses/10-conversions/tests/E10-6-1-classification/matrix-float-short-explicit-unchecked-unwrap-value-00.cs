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
            float? input = 0.0f;
            short result = unchecked((short)input);
            Check(result==(short)(0), "nullable-float-short-explicit-unchecked-unwrap-2");
        }
        {
            float? input = -0.0f;
            short result = unchecked((short)input);
            Check(result==(short)(0), "nullable-float-short-explicit-unchecked-unwrap-3");
        }
        {
            float? input = 1.0f;
            short result = unchecked((short)input);
            Check(result==(short)(1), "nullable-float-short-explicit-unchecked-unwrap-4");
        }
        {
            float? input = -1.0f;
            short result = unchecked((short)input);
            Check(result==(short)(-1), "nullable-float-short-explicit-unchecked-unwrap-5");
        }
        {
            float? input = 0.75f;
            short result = unchecked((short)input);
            Check(result==(short)(0), "nullable-float-short-explicit-unchecked-unwrap-6");
        }
        {
            float? input = -0.75f;
            short result = unchecked((short)input);
            Check(result==(short)(0), "nullable-float-short-explicit-unchecked-unwrap-7");
        }
        {
            float? input = -32768.0f;
            short result = unchecked((short)input);
            Check(result==(short)(-32768), "nullable-float-short-explicit-unchecked-unwrap-12");
        }
        {
            float? input = -32767.0f;
            short result = unchecked((short)input);
            Check(result==(short)(-32767), "nullable-float-short-explicit-unchecked-unwrap-13");
        }
        {
            float? input = 32766.0f;
            short result = unchecked((short)input);
            Check(result==(short)(32766), "nullable-float-short-explicit-unchecked-unwrap-14");
        }
        {
            float? input = 32767.0f;
            short result = unchecked((short)input);
            Check(result==(short)(32767), "nullable-float-short-explicit-unchecked-unwrap-15");
        }
        {
            float? input = -32768.75f;
            short result = unchecked((short)input);
            Check(result==(short)(-32768), "nullable-float-short-explicit-unchecked-unwrap-17");
        }
        {
            float? input = 32767.75f;
            short result = unchecked((short)input);
            Check(result==(short)(32767), "nullable-float-short-explicit-unchecked-unwrap-18");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
