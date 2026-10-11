/*
Rules: E10-2-2-same
Authority: ECMA-334 7th ed 10.2.2
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
            byte result = unchecked(input);
            Check(result==(byte)(0), "byte-byte-implicit-unchecked-variable-0");
        }
        {
            byte input = (byte)(255);
            byte result = unchecked(input);
            Check(result==(byte)(255), "byte-byte-implicit-unchecked-variable-1");
        }
        {
            byte input = (byte)(1);
            byte result = unchecked(input);
            Check(result==(byte)(1), "byte-byte-implicit-unchecked-variable-2");
        }
        {
            byte input = (byte)(254);
            byte result = unchecked(input);
            Check(result==(byte)(254), "byte-byte-implicit-unchecked-variable-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
