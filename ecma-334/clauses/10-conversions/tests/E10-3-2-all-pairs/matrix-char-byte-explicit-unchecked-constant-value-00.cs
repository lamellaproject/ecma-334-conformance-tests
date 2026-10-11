/*
Rules: E10-3-2-all-pairs; E10-3-2-char; E12-23-numeric
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
            const char input = (char)(0);
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "char-byte-explicit-unchecked-constant-0");
        }
        {
            const char input = (char)(65535);
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "char-byte-explicit-unchecked-constant-1");
        }
        {
            const char input = (char)(1);
            byte result = unchecked((byte)input);
            Check(result==(byte)(1), "char-byte-explicit-unchecked-constant-2");
        }
        {
            const char input = (char)(254);
            byte result = unchecked((byte)input);
            Check(result==(byte)(254), "char-byte-explicit-unchecked-constant-3");
        }
        {
            const char input = (char)(255);
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "char-byte-explicit-unchecked-constant-4");
        }
        {
            const char input = (char)(256);
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "char-byte-explicit-unchecked-constant-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
