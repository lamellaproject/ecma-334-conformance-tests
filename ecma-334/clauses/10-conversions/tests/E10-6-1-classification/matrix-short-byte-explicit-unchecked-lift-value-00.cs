/*
Rules: E10-6-1-classification; E10-6-1-nonnull
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 8
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
            short? input = (short)(-32768);
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(0), "nullable-short-byte-explicit-unchecked-lift-0");
        }
        {
            short? input = (short)(32767);
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(255), "nullable-short-byte-explicit-unchecked-lift-1");
        }
        {
            short? input = (short)(0);
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(0), "nullable-short-byte-explicit-unchecked-lift-2");
        }
        {
            short? input = (short)(1);
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(1), "nullable-short-byte-explicit-unchecked-lift-3");
        }
        {
            short? input = (short)(-1);
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(255), "nullable-short-byte-explicit-unchecked-lift-4");
        }
        {
            short? input = (short)(254);
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(254), "nullable-short-byte-explicit-unchecked-lift-5");
        }
        {
            short? input = (short)(255);
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(255), "nullable-short-byte-explicit-unchecked-lift-6");
        }
        {
            short? input = (short)(256);
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(0), "nullable-short-byte-explicit-unchecked-lift-7");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
