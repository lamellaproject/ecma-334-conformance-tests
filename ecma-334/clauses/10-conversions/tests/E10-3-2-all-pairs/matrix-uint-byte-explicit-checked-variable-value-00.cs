/*
Rules: E10-3-2-all-pairs; E10-3-2-uint
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
            uint input = 0U;
            byte result = checked((byte)input);
            Check(result==(byte)(0), "uint-byte-explicit-checked-variable-0");
        }
        {
            uint input = 1U;
            byte result = checked((byte)input);
            Check(result==(byte)(1), "uint-byte-explicit-checked-variable-2");
        }
        {
            uint input = 254U;
            byte result = checked((byte)input);
            Check(result==(byte)(254), "uint-byte-explicit-checked-variable-3");
        }
        {
            uint input = 255U;
            byte result = checked((byte)input);
            Check(result==(byte)(255), "uint-byte-explicit-checked-variable-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
