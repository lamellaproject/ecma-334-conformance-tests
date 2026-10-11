/*
Rules: E10-3-2-all-pairs; E10-3-2-float; E12-23-numeric
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
            const float input = 0.0f;
            short result = unchecked((short)input);
            Check(result==(short)(0), "float-short-explicit-unchecked-constant-2");
        }
        {
            const float input = -0.0f;
            short result = unchecked((short)input);
            Check(result==(short)(0), "float-short-explicit-unchecked-constant-3");
        }
        {
            const float input = 1.0f;
            short result = unchecked((short)input);
            Check(result==(short)(1), "float-short-explicit-unchecked-constant-4");
        }
        {
            const float input = -1.0f;
            short result = unchecked((short)input);
            Check(result==(short)(-1), "float-short-explicit-unchecked-constant-5");
        }
        {
            const float input = 0.75f;
            short result = unchecked((short)input);
            Check(result==(short)(0), "float-short-explicit-unchecked-constant-6");
        }
        {
            const float input = -0.75f;
            short result = unchecked((short)input);
            Check(result==(short)(0), "float-short-explicit-unchecked-constant-7");
        }
        {
            const float input = -32768.0f;
            short result = unchecked((short)input);
            Check(result==(short)(-32768), "float-short-explicit-unchecked-constant-12");
        }
        {
            const float input = -32767.0f;
            short result = unchecked((short)input);
            Check(result==(short)(-32767), "float-short-explicit-unchecked-constant-13");
        }
        {
            const float input = 32766.0f;
            short result = unchecked((short)input);
            Check(result==(short)(32766), "float-short-explicit-unchecked-constant-14");
        }
        {
            const float input = 32767.0f;
            short result = unchecked((short)input);
            Check(result==(short)(32767), "float-short-explicit-unchecked-constant-15");
        }
        {
            const float input = -32768.75f;
            short result = unchecked((short)input);
            Check(result==(short)(-32768), "float-short-explicit-unchecked-constant-17");
        }
        {
            const float input = 32767.75f;
            short result = unchecked((short)input);
            Check(result==(short)(32767), "float-short-explicit-unchecked-constant-18");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
