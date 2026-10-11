/*
Rules: E10-3-2-all-pairs; E10-3-2-float
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
            float input = 0.0f;
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "float-byte-explicit-unchecked-variable-2");
        }
        {
            float input = -0.0f;
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "float-byte-explicit-unchecked-variable-3");
        }
        {
            float input = 1.0f;
            byte result = unchecked((byte)input);
            Check(result==(byte)(1), "float-byte-explicit-unchecked-variable-4");
        }
        {
            float input = 0.75f;
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "float-byte-explicit-unchecked-variable-6");
        }
        {
            float input = -0.75f;
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "float-byte-explicit-unchecked-variable-7");
        }
        {
            float input = 254.0f;
            byte result = unchecked((byte)input);
            Check(result==(byte)(254), "float-byte-explicit-unchecked-variable-11");
        }
        {
            float input = 255.0f;
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "float-byte-explicit-unchecked-variable-12");
        }
        {
            float input = 255.75f;
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "float-byte-explicit-unchecked-variable-14");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
