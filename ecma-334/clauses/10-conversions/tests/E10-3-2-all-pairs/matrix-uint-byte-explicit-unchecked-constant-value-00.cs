/*
Rules: E10-3-2-all-pairs; E10-3-2-uint; E12-23-numeric
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 6
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
            const uint input = 0U;
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "uint-byte-explicit-unchecked-constant-0");
        }
        {
            const uint input = 4294967295U;
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "uint-byte-explicit-unchecked-constant-1");
        }
        {
            const uint input = 1U;
            byte result = unchecked((byte)input);
            Check(result==(byte)(1), "uint-byte-explicit-unchecked-constant-2");
        }
        {
            const uint input = 254U;
            byte result = unchecked((byte)input);
            Check(result==(byte)(254), "uint-byte-explicit-unchecked-constant-3");
        }
        {
            const uint input = 255U;
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "uint-byte-explicit-unchecked-constant-4");
        }
        {
            const uint input = 256U;
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "uint-byte-explicit-unchecked-constant-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
