/*
Rules: E10-3-2-all-pairs; E10-3-2-double
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
            double input = 0.0d;
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "double-byte-explicit-unchecked-variable-2");
        }
        {
            double input = -0.0d;
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "double-byte-explicit-unchecked-variable-3");
        }
        {
            double input = 1.0d;
            byte result = unchecked((byte)input);
            Check(result==(byte)(1), "double-byte-explicit-unchecked-variable-4");
        }
        {
            double input = 0.75d;
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "double-byte-explicit-unchecked-variable-6");
        }
        {
            double input = -0.75d;
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "double-byte-explicit-unchecked-variable-7");
        }
        {
            double input = 254.0d;
            byte result = unchecked((byte)input);
            Check(result==(byte)(254), "double-byte-explicit-unchecked-variable-11");
        }
        {
            double input = 255.0d;
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "double-byte-explicit-unchecked-variable-12");
        }
        {
            double input = 255.75d;
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "double-byte-explicit-unchecked-variable-14");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
