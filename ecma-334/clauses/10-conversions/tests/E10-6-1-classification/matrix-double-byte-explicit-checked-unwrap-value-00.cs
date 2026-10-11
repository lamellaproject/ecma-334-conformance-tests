/*
Rules: E10-6-1-classification; E10-6-1-unwrap
Authority: ECMA-334 7th ed 10.6.1
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
            double? input = 0.0d;
            byte result = checked((byte)input);
            Check(result==(byte)(0), "nullable-double-byte-explicit-checked-unwrap-2");
        }
        {
            double? input = -0.0d;
            byte result = checked((byte)input);
            Check(result==(byte)(0), "nullable-double-byte-explicit-checked-unwrap-3");
        }
        {
            double? input = 1.0d;
            byte result = checked((byte)input);
            Check(result==(byte)(1), "nullable-double-byte-explicit-checked-unwrap-4");
        }
        {
            double? input = 0.75d;
            byte result = checked((byte)input);
            Check(result==(byte)(0), "nullable-double-byte-explicit-checked-unwrap-6");
        }
        {
            double? input = -0.75d;
            byte result = checked((byte)input);
            Check(result==(byte)(0), "nullable-double-byte-explicit-checked-unwrap-7");
        }
        {
            double? input = 254.0d;
            byte result = checked((byte)input);
            Check(result==(byte)(254), "nullable-double-byte-explicit-checked-unwrap-11");
        }
        {
            double? input = 255.0d;
            byte result = checked((byte)input);
            Check(result==(byte)(255), "nullable-double-byte-explicit-checked-unwrap-12");
        }
        {
            double? input = 255.75d;
            byte result = checked((byte)input);
            Check(result==(byte)(255), "nullable-double-byte-explicit-checked-unwrap-14");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
