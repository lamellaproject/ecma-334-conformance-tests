/*
Rules: E10-3-2-all-pairs; E10-3-2-byte
Authority: ECMA-334 7th ed 10.3.2
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
            byte input = (byte)(0);
            char result = unchecked((char)input);
            Check(result==(char)(0), "byte-char-explicit-unchecked-variable-0");
        }
        {
            byte input = (byte)(255);
            char result = unchecked((char)input);
            Check(result==(char)(255), "byte-char-explicit-unchecked-variable-1");
        }
        {
            byte input = (byte)(1);
            char result = unchecked((char)input);
            Check(result==(char)(1), "byte-char-explicit-unchecked-variable-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
