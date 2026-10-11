/*
Rules: E10-3-2-all-pairs
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 4
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
            byte input = (byte)(0);
            byte result = checked((byte)input);
            Check(result==(byte)(0), "byte-byte-explicit-checked-variable-0");
        }
        {
            byte input = (byte)(255);
            byte result = checked((byte)input);
            Check(result==(byte)(255), "byte-byte-explicit-checked-variable-1");
        }
        {
            byte input = (byte)(1);
            byte result = checked((byte)input);
            Check(result==(byte)(1), "byte-byte-explicit-checked-variable-2");
        }
        {
            byte input = (byte)(254);
            byte result = checked((byte)input);
            Check(result==(byte)(254), "byte-byte-explicit-checked-variable-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
