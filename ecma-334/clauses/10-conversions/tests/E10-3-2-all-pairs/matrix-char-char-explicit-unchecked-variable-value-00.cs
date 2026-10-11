/*
Rules: E10-3-2-all-pairs
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
            char result = unchecked((char)input);
            Check(result==(char)(0), "char-char-explicit-unchecked-variable-0");
        }
        {
            char input = (char)(65535);
            char result = unchecked((char)input);
            Check(result==(char)(65535), "char-char-explicit-unchecked-variable-1");
        }
        {
            char input = (char)(1);
            char result = unchecked((char)input);
            Check(result==(char)(1), "char-char-explicit-unchecked-variable-2");
        }
        {
            char input = (char)(65534);
            char result = unchecked((char)input);
            Check(result==(char)(65534), "char-char-explicit-unchecked-variable-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
