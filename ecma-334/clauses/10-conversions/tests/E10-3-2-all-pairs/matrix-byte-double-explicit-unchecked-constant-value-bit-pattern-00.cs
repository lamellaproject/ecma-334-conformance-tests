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
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==0UL, "byte-double-explicit-unchecked-constant-0");
        }
        {
            const byte input = (byte)(255);
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4643176031446892544UL, "byte-double-explicit-unchecked-constant-1");
        }
        {
            const byte input = (byte)(1);
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4607182418800017408UL, "byte-double-explicit-unchecked-constant-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
