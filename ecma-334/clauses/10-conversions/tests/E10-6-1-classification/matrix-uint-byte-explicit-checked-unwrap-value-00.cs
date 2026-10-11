/*
Rules: E10-6-1-classification; E10-6-1-unwrap
Authority: ECMA-334 7th ed 10.6.1
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
            uint? input = 0U;
            byte result = checked((byte)input);
            Check(result==(byte)(0), "nullable-uint-byte-explicit-checked-unwrap-0");
        }
        {
            uint? input = 1U;
            byte result = checked((byte)input);
            Check(result==(byte)(1), "nullable-uint-byte-explicit-checked-unwrap-2");
        }
        {
            uint? input = 254U;
            byte result = checked((byte)input);
            Check(result==(byte)(254), "nullable-uint-byte-explicit-checked-unwrap-3");
        }
        {
            uint? input = 255U;
            byte result = checked((byte)input);
            Check(result==(byte)(255), "nullable-uint-byte-explicit-checked-unwrap-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
