/*
Rules: E10-3-2-all-pairs; E10-3-2-ushort
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
            ushort input = (ushort)(0);
            char result = unchecked((char)input);
            Check(result==(char)(0), "ushort-char-explicit-unchecked-variable-0");
        }
        {
            ushort input = (ushort)(65535);
            char result = unchecked((char)input);
            Check(result==(char)(65535), "ushort-char-explicit-unchecked-variable-1");
        }
        {
            ushort input = (ushort)(1);
            char result = unchecked((char)input);
            Check(result==(char)(1), "ushort-char-explicit-unchecked-variable-2");
        }
        {
            ushort input = (ushort)(65534);
            char result = unchecked((char)input);
            Check(result==(char)(65534), "ushort-char-explicit-unchecked-variable-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
