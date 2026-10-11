/*
Rules: E10-3-2-all-pairs; E10-3-2-char
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 4
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
            short result = checked((short)input);
            Check(result==(short)(0), "char-short-explicit-checked-variable-0");
        }
        {
            char input = (char)(1);
            short result = checked((short)input);
            Check(result==(short)(1), "char-short-explicit-checked-variable-2");
        }
        {
            char input = (char)(32766);
            short result = checked((short)input);
            Check(result==(short)(32766), "char-short-explicit-checked-variable-3");
        }
        {
            char input = (char)(32767);
            short result = checked((short)input);
            Check(result==(short)(32767), "char-short-explicit-checked-variable-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
