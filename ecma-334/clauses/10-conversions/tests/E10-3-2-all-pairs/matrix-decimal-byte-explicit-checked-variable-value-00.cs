/*
Rules: E10-3-2-all-pairs; E10-3-2-decimal
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 10
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
            decimal input = 0m;
            byte result = checked((byte)input);
            Check(result==(byte)(0), "decimal-byte-explicit-checked-variable-2");
        }
        {
            decimal input = 1m;
            byte result = checked((byte)input);
            Check(result==(byte)(1), "decimal-byte-explicit-checked-variable-3");
        }
        {
            decimal input = 0.1m;
            byte result = checked((byte)input);
            Check(result==(byte)(0), "decimal-byte-explicit-checked-variable-5");
        }
        {
            decimal input = -0.1m;
            byte result = checked((byte)input);
            Check(result==(byte)(0), "decimal-byte-explicit-checked-variable-6");
        }
        {
            decimal input = 1E-28m;
            byte result = checked((byte)input);
            Check(result==(byte)(0), "decimal-byte-explicit-checked-variable-7");
        }
        {
            decimal input = -1E-28m;
            byte result = checked((byte)input);
            Check(result==(byte)(0), "decimal-byte-explicit-checked-variable-8");
        }
        {
            decimal input = 254m;
            byte result = checked((byte)input);
            Check(result==(byte)(254), "decimal-byte-explicit-checked-variable-9");
        }
        {
            decimal input = 255m;
            byte result = checked((byte)input);
            Check(result==(byte)(255), "decimal-byte-explicit-checked-variable-10");
        }
        {
            decimal input = -0.75m;
            byte result = checked((byte)input);
            Check(result==(byte)(0), "decimal-byte-explicit-checked-variable-12");
        }
        {
            decimal input = 255.75m;
            byte result = checked((byte)input);
            Check(result==(byte)(255), "decimal-byte-explicit-checked-variable-13");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
