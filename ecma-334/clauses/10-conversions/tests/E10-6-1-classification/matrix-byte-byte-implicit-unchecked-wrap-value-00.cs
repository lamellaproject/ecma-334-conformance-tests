/*
Rules: E10-6-1-classification; E10-6-1-wrap
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
            byte input = (byte)(0);
            byte? result = unchecked(input);
            Check(result.HasValue && result.Value==(byte)(0), "nullable-byte-byte-implicit-unchecked-wrap-0");
        }
        {
            byte input = (byte)(255);
            byte? result = unchecked(input);
            Check(result.HasValue && result.Value==(byte)(255), "nullable-byte-byte-implicit-unchecked-wrap-1");
        }
        {
            byte input = (byte)(1);
            byte? result = unchecked(input);
            Check(result.HasValue && result.Value==(byte)(1), "nullable-byte-byte-implicit-unchecked-wrap-2");
        }
        {
            byte input = (byte)(254);
            byte? result = unchecked(input);
            Check(result.HasValue && result.Value==(byte)(254), "nullable-byte-byte-implicit-unchecked-wrap-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
