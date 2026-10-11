/*
Rules: E10-6-1-classification; E10-6-1-unwrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 3
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
            short? input = (short)(32767);
            char result = checked((char)input);
            Check(result==(char)(32767), "nullable-short-char-explicit-checked-unwrap-1");
        }
        {
            short? input = (short)(0);
            char result = checked((char)input);
            Check(result==(char)(0), "nullable-short-char-explicit-checked-unwrap-2");
        }
        {
            short? input = (short)(1);
            char result = checked((char)input);
            Check(result==(char)(1), "nullable-short-char-explicit-checked-unwrap-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
