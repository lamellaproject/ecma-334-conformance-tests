/*
Rules: E10-3-2-all-pairs; E10-3-2-float; E12-23-numeric
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
            const float input = 0.0f;
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "float-byte-explicit-unchecked-constant-2");
        }
        {
            const float input = -0.0f;
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "float-byte-explicit-unchecked-constant-3");
        }
        {
            const float input = 1.0f;
            byte result = unchecked((byte)input);
            Check(result==(byte)(1), "float-byte-explicit-unchecked-constant-4");
        }
        {
            const float input = 0.75f;
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "float-byte-explicit-unchecked-constant-6");
        }
        {
            const float input = -0.75f;
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "float-byte-explicit-unchecked-constant-7");
        }
        {
            const float input = 254.0f;
            byte result = unchecked((byte)input);
            Check(result==(byte)(254), "float-byte-explicit-unchecked-constant-11");
        }
        {
            const float input = 255.0f;
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "float-byte-explicit-unchecked-constant-12");
        }
        {
            const float input = 255.75f;
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "float-byte-explicit-unchecked-constant-14");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
