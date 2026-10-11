/*
Rules: E10-3-2-all-pairs; E10-3-2-int
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
            int input = -2147483648;
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "int-byte-explicit-unchecked-variable-0");
        }
        {
            int input = 2147483647;
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "int-byte-explicit-unchecked-variable-1");
        }
        {
            int input = 0;
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "int-byte-explicit-unchecked-variable-2");
        }
        {
            int input = 1;
            byte result = unchecked((byte)input);
            Check(result==(byte)(1), "int-byte-explicit-unchecked-variable-3");
        }
        {
            int input = -1;
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "int-byte-explicit-unchecked-variable-4");
        }
        {
            int input = 254;
            byte result = unchecked((byte)input);
            Check(result==(byte)(254), "int-byte-explicit-unchecked-variable-5");
        }
        {
            int input = 255;
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "int-byte-explicit-unchecked-variable-6");
        }
        {
            int input = 256;
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "int-byte-explicit-unchecked-variable-7");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
