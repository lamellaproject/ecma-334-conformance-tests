/*
Rules: E10-3-2-all-pairs; E10-3-2-int
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
            int input = 0;
            short result = checked((short)input);
            Check(result==(short)(0), "int-short-explicit-checked-variable-2");
        }
        {
            int input = 1;
            short result = checked((short)input);
            Check(result==(short)(1), "int-short-explicit-checked-variable-3");
        }
        {
            int input = -1;
            short result = checked((short)input);
            Check(result==(short)(-1), "int-short-explicit-checked-variable-4");
        }
        {
            int input = -32768;
            short result = checked((short)input);
            Check(result==(short)(-32768), "int-short-explicit-checked-variable-6");
        }
        {
            int input = -32767;
            short result = checked((short)input);
            Check(result==(short)(-32767), "int-short-explicit-checked-variable-7");
        }
        {
            int input = 32766;
            short result = checked((short)input);
            Check(result==(short)(32766), "int-short-explicit-checked-variable-8");
        }
        {
            int input = 32767;
            short result = checked((short)input);
            Check(result==(short)(32767), "int-short-explicit-checked-variable-9");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
