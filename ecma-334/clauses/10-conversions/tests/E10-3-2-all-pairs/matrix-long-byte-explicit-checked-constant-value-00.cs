/*
Rules: E10-3-2-all-pairs; E10-3-2-long; E12-23-numeric
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
            const long input = 0L;
            byte result = checked((byte)input);
            Check(result==(byte)(0), "long-byte-explicit-checked-constant-2");
        }
        {
            const long input = 1L;
            byte result = checked((byte)input);
            Check(result==(byte)(1), "long-byte-explicit-checked-constant-3");
        }
        {
            const long input = 254L;
            byte result = checked((byte)input);
            Check(result==(byte)(254), "long-byte-explicit-checked-constant-5");
        }
        {
            const long input = 255L;
            byte result = checked((byte)input);
            Check(result==(byte)(255), "long-byte-explicit-checked-constant-6");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
