/*
Rules: E10-3-2-all-pairs; E10-3-2-short
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
            short input = (short)(-32768);
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "short-byte-explicit-unchecked-variable-0");
        }
        {
            short input = (short)(32767);
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "short-byte-explicit-unchecked-variable-1");
        }
        {
            short input = (short)(0);
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "short-byte-explicit-unchecked-variable-2");
        }
        {
            short input = (short)(1);
            byte result = unchecked((byte)input);
            Check(result==(byte)(1), "short-byte-explicit-unchecked-variable-3");
        }
        {
            short input = (short)(-1);
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "short-byte-explicit-unchecked-variable-4");
        }
        {
            short input = (short)(254);
            byte result = unchecked((byte)input);
            Check(result==(byte)(254), "short-byte-explicit-unchecked-variable-5");
        }
        {
            short input = (short)(255);
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "short-byte-explicit-unchecked-variable-6");
        }
        {
            short input = (short)(256);
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "short-byte-explicit-unchecked-variable-7");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
