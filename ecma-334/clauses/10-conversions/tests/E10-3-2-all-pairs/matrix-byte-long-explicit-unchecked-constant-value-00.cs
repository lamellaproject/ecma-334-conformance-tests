/*
Rules: E10-3-2-all-pairs; E10-3-2-byte; E12-23-numeric
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 3
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
            const byte input = (byte)(0);
            long result = unchecked((long)input);
            Check(result==0L, "byte-long-explicit-unchecked-constant-0");
        }
        {
            const byte input = (byte)(255);
            long result = unchecked((long)input);
            Check(result==255L, "byte-long-explicit-unchecked-constant-1");
        }
        {
            const byte input = (byte)(1);
            long result = unchecked((long)input);
            Check(result==1L, "byte-long-explicit-unchecked-constant-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
