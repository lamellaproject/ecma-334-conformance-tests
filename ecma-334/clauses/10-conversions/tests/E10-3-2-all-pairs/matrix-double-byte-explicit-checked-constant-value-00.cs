/*
Rules: E10-3-2-all-pairs; E10-3-2-double; E12-23-numeric
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
            const double input = 0.0d;
            byte result = checked((byte)input);
            Check(result==(byte)(0), "double-byte-explicit-checked-constant-2");
        }
        {
            const double input = -0.0d;
            byte result = checked((byte)input);
            Check(result==(byte)(0), "double-byte-explicit-checked-constant-3");
        }
        {
            const double input = 1.0d;
            byte result = checked((byte)input);
            Check(result==(byte)(1), "double-byte-explicit-checked-constant-4");
        }
        {
            const double input = 0.75d;
            byte result = checked((byte)input);
            Check(result==(byte)(0), "double-byte-explicit-checked-constant-6");
        }
        {
            const double input = -0.75d;
            byte result = checked((byte)input);
            Check(result==(byte)(0), "double-byte-explicit-checked-constant-7");
        }
        {
            const double input = 254.0d;
            byte result = checked((byte)input);
            Check(result==(byte)(254), "double-byte-explicit-checked-constant-11");
        }
        {
            const double input = 255.0d;
            byte result = checked((byte)input);
            Check(result==(byte)(255), "double-byte-explicit-checked-constant-12");
        }
        {
            const double input = 255.75d;
            byte result = checked((byte)input);
            Check(result==(byte)(255), "double-byte-explicit-checked-constant-14");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
