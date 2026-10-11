/*
Rules: E10-6-1-classification; E10-6-1-nonnull
Authority: ECMA-334 7th ed 10.6.1
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
            byte? input = (byte)(0);
            short? result = unchecked((short?)input);
            Check(result.HasValue && result.Value==(short)(0), "nullable-byte-short-explicit-unchecked-lift-0");
        }
        {
            byte? input = (byte)(255);
            short? result = unchecked((short?)input);
            Check(result.HasValue && result.Value==(short)(255), "nullable-byte-short-explicit-unchecked-lift-1");
        }
        {
            byte? input = (byte)(1);
            short? result = unchecked((short?)input);
            Check(result.HasValue && result.Value==(short)(1), "nullable-byte-short-explicit-unchecked-lift-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
