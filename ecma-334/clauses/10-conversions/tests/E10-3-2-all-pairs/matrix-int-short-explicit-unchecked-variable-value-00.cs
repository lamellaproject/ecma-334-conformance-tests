/*
Rules: E10-3-2-all-pairs; E10-3-2-int
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
            int input = -2147483648;
            short result = unchecked((short)input);
            Check(result==(short)(0), "int-short-explicit-unchecked-variable-0");
        }
        {
            int input = 2147483647;
            short result = unchecked((short)input);
            Check(result==(short)(-1), "int-short-explicit-unchecked-variable-1");
        }
        {
            int input = 0;
            short result = unchecked((short)input);
            Check(result==(short)(0), "int-short-explicit-unchecked-variable-2");
        }
        {
            int input = 1;
            short result = unchecked((short)input);
            Check(result==(short)(1), "int-short-explicit-unchecked-variable-3");
        }
        {
            int input = -1;
            short result = unchecked((short)input);
            Check(result==(short)(-1), "int-short-explicit-unchecked-variable-4");
        }
        {
            int input = -32769;
            short result = unchecked((short)input);
            Check(result==(short)(32767), "int-short-explicit-unchecked-variable-5");
        }
        {
            int input = -32768;
            short result = unchecked((short)input);
            Check(result==(short)(-32768), "int-short-explicit-unchecked-variable-6");
        }
        {
            int input = -32767;
            short result = unchecked((short)input);
            Check(result==(short)(-32767), "int-short-explicit-unchecked-variable-7");
        }
        {
            int input = 32766;
            short result = unchecked((short)input);
            Check(result==(short)(32766), "int-short-explicit-unchecked-variable-8");
        }
        {
            int input = 32767;
            short result = unchecked((short)input);
            Check(result==(short)(32767), "int-short-explicit-unchecked-variable-9");
        }
        {
            int input = 32768;
            short result = unchecked((short)input);
            Check(result==(short)(-32768), "int-short-explicit-unchecked-variable-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
