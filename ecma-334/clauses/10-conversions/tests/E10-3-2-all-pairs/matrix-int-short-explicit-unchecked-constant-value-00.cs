/*
Rules: E10-3-2-all-pairs; E10-3-2-int; E12-23-numeric
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
            const int input = -2147483648;
            short result = unchecked((short)input);
            Check(result==(short)(0), "int-short-explicit-unchecked-constant-0");
        }
        {
            const int input = 2147483647;
            short result = unchecked((short)input);
            Check(result==(short)(-1), "int-short-explicit-unchecked-constant-1");
        }
        {
            const int input = 0;
            short result = unchecked((short)input);
            Check(result==(short)(0), "int-short-explicit-unchecked-constant-2");
        }
        {
            const int input = 1;
            short result = unchecked((short)input);
            Check(result==(short)(1), "int-short-explicit-unchecked-constant-3");
        }
        {
            const int input = -1;
            short result = unchecked((short)input);
            Check(result==(short)(-1), "int-short-explicit-unchecked-constant-4");
        }
        {
            const int input = -32769;
            short result = unchecked((short)input);
            Check(result==(short)(32767), "int-short-explicit-unchecked-constant-5");
        }
        {
            const int input = -32768;
            short result = unchecked((short)input);
            Check(result==(short)(-32768), "int-short-explicit-unchecked-constant-6");
        }
        {
            const int input = -32767;
            short result = unchecked((short)input);
            Check(result==(short)(-32767), "int-short-explicit-unchecked-constant-7");
        }
        {
            const int input = 32766;
            short result = unchecked((short)input);
            Check(result==(short)(32766), "int-short-explicit-unchecked-constant-8");
        }
        {
            const int input = 32767;
            short result = unchecked((short)input);
            Check(result==(short)(32767), "int-short-explicit-unchecked-constant-9");
        }
        {
            const int input = 32768;
            short result = unchecked((short)input);
            Check(result==(short)(-32768), "int-short-explicit-unchecked-constant-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
