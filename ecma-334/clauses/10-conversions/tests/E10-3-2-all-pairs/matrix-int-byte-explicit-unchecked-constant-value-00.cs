/*
Rules: E10-3-2-all-pairs; E10-3-2-int; E12-23-numeric
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
            const int input = -2147483648;
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "int-byte-explicit-unchecked-constant-0");
        }
        {
            const int input = 2147483647;
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "int-byte-explicit-unchecked-constant-1");
        }
        {
            const int input = 0;
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "int-byte-explicit-unchecked-constant-2");
        }
        {
            const int input = 1;
            byte result = unchecked((byte)input);
            Check(result==(byte)(1), "int-byte-explicit-unchecked-constant-3");
        }
        {
            const int input = -1;
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "int-byte-explicit-unchecked-constant-4");
        }
        {
            const int input = 254;
            byte result = unchecked((byte)input);
            Check(result==(byte)(254), "int-byte-explicit-unchecked-constant-5");
        }
        {
            const int input = 255;
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "int-byte-explicit-unchecked-constant-6");
        }
        {
            const int input = 256;
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "int-byte-explicit-unchecked-constant-7");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
