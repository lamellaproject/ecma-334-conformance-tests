/*
Rules: E10-6-1-classification; E10-6-1-unwrap
Authority: ECMA-334 7th ed 10.6.1
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
            int? input = -2147483648;
            short result = unchecked((short)input);
            Check(result==(short)(0), "nullable-int-short-explicit-unchecked-unwrap-0");
        }
        {
            int? input = 2147483647;
            short result = unchecked((short)input);
            Check(result==(short)(-1), "nullable-int-short-explicit-unchecked-unwrap-1");
        }
        {
            int? input = 0;
            short result = unchecked((short)input);
            Check(result==(short)(0), "nullable-int-short-explicit-unchecked-unwrap-2");
        }
        {
            int? input = 1;
            short result = unchecked((short)input);
            Check(result==(short)(1), "nullable-int-short-explicit-unchecked-unwrap-3");
        }
        {
            int? input = -1;
            short result = unchecked((short)input);
            Check(result==(short)(-1), "nullable-int-short-explicit-unchecked-unwrap-4");
        }
        {
            int? input = -32769;
            short result = unchecked((short)input);
            Check(result==(short)(32767), "nullable-int-short-explicit-unchecked-unwrap-5");
        }
        {
            int? input = -32768;
            short result = unchecked((short)input);
            Check(result==(short)(-32768), "nullable-int-short-explicit-unchecked-unwrap-6");
        }
        {
            int? input = -32767;
            short result = unchecked((short)input);
            Check(result==(short)(-32767), "nullable-int-short-explicit-unchecked-unwrap-7");
        }
        {
            int? input = 32766;
            short result = unchecked((short)input);
            Check(result==(short)(32766), "nullable-int-short-explicit-unchecked-unwrap-8");
        }
        {
            int? input = 32767;
            short result = unchecked((short)input);
            Check(result==(short)(32767), "nullable-int-short-explicit-unchecked-unwrap-9");
        }
        {
            int? input = 32768;
            short result = unchecked((short)input);
            Check(result==(short)(-32768), "nullable-int-short-explicit-unchecked-unwrap-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
