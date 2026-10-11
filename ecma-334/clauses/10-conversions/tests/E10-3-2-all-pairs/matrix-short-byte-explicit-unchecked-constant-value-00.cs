/*
Rules: E10-3-2-all-pairs; E10-3-2-short; E12-23-numeric
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 8
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
            const short input = (short)(-32768);
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "short-byte-explicit-unchecked-constant-0");
        }
        {
            const short input = (short)(32767);
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "short-byte-explicit-unchecked-constant-1");
        }
        {
            const short input = (short)(0);
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "short-byte-explicit-unchecked-constant-2");
        }
        {
            const short input = (short)(1);
            byte result = unchecked((byte)input);
            Check(result==(byte)(1), "short-byte-explicit-unchecked-constant-3");
        }
        {
            const short input = (short)(-1);
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "short-byte-explicit-unchecked-constant-4");
        }
        {
            const short input = (short)(254);
            byte result = unchecked((byte)input);
            Check(result==(byte)(254), "short-byte-explicit-unchecked-constant-5");
        }
        {
            const short input = (short)(255);
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "short-byte-explicit-unchecked-constant-6");
        }
        {
            const short input = (short)(256);
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "short-byte-explicit-unchecked-constant-7");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
