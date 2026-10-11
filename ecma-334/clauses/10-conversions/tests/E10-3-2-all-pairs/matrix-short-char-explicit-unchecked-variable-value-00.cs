/*
Rules: E10-3-2-all-pairs; E10-3-2-short
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 5
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
            short input = (short)(-32768);
            char result = unchecked((char)input);
            Check(result==(char)(32768), "short-char-explicit-unchecked-variable-0");
        }
        {
            short input = (short)(32767);
            char result = unchecked((char)input);
            Check(result==(char)(32767), "short-char-explicit-unchecked-variable-1");
        }
        {
            short input = (short)(0);
            char result = unchecked((char)input);
            Check(result==(char)(0), "short-char-explicit-unchecked-variable-2");
        }
        {
            short input = (short)(1);
            char result = unchecked((char)input);
            Check(result==(char)(1), "short-char-explicit-unchecked-variable-3");
        }
        {
            short input = (short)(-1);
            char result = unchecked((char)input);
            Check(result==(char)(65535), "short-char-explicit-unchecked-variable-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
