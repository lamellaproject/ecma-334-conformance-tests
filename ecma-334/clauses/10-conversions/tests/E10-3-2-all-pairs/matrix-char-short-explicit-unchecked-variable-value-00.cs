/*
Rules: E10-3-2-all-pairs; E10-3-2-char
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 6
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
            char input = (char)(0);
            short result = unchecked((short)input);
            Check(result==(short)(0), "char-short-explicit-unchecked-variable-0");
        }
        {
            char input = (char)(65535);
            short result = unchecked((short)input);
            Check(result==(short)(-1), "char-short-explicit-unchecked-variable-1");
        }
        {
            char input = (char)(1);
            short result = unchecked((short)input);
            Check(result==(short)(1), "char-short-explicit-unchecked-variable-2");
        }
        {
            char input = (char)(32766);
            short result = unchecked((short)input);
            Check(result==(short)(32766), "char-short-explicit-unchecked-variable-3");
        }
        {
            char input = (char)(32767);
            short result = unchecked((short)input);
            Check(result==(short)(32767), "char-short-explicit-unchecked-variable-4");
        }
        {
            char input = (char)(32768);
            short result = unchecked((short)input);
            Check(result==(short)(-32768), "char-short-explicit-unchecked-variable-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
