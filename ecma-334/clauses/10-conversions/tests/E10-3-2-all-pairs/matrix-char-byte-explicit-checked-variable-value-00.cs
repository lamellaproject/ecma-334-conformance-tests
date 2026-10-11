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
            byte result = checked((byte)input);
            Check(result==(byte)(0), "char-byte-explicit-checked-variable-0");
        }
        {
            char input = (char)(1);
            byte result = checked((byte)input);
            Check(result==(byte)(1), "char-byte-explicit-checked-variable-2");
        }
        {
            char input = (char)(254);
            byte result = checked((byte)input);
            Check(result==(byte)(254), "char-byte-explicit-checked-variable-3");
        }
        {
            char input = (char)(255);
            byte result = checked((byte)input);
            Check(result==(byte)(255), "char-byte-explicit-checked-variable-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
