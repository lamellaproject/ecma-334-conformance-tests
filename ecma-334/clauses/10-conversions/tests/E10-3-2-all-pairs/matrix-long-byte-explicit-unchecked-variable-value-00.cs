/*
Rules: E10-3-2-all-pairs; E10-3-2-long
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
            long input = long.MinValue;
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "long-byte-explicit-unchecked-variable-0");
        }
        {
            long input = 9223372036854775807L;
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "long-byte-explicit-unchecked-variable-1");
        }
        {
            long input = 0L;
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "long-byte-explicit-unchecked-variable-2");
        }
        {
            long input = 1L;
            byte result = unchecked((byte)input);
            Check(result==(byte)(1), "long-byte-explicit-unchecked-variable-3");
        }
        {
            long input = -1L;
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "long-byte-explicit-unchecked-variable-4");
        }
        {
            long input = 254L;
            byte result = unchecked((byte)input);
            Check(result==(byte)(254), "long-byte-explicit-unchecked-variable-5");
        }
        {
            long input = 255L;
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "long-byte-explicit-unchecked-variable-6");
        }
        {
            long input = 256L;
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "long-byte-explicit-unchecked-variable-7");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
