/*
Rules: E10-6-1-classification; E10-6-1-nonnull
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 10
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
            decimal? input = 0m;
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(0), "nullable-decimal-byte-explicit-unchecked-lift-2");
        }
        {
            decimal? input = 1m;
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(1), "nullable-decimal-byte-explicit-unchecked-lift-3");
        }
        {
            decimal? input = 0.1m;
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(0), "nullable-decimal-byte-explicit-unchecked-lift-5");
        }
        {
            decimal? input = -0.1m;
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(0), "nullable-decimal-byte-explicit-unchecked-lift-6");
        }
        {
            decimal? input = 1E-28m;
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(0), "nullable-decimal-byte-explicit-unchecked-lift-7");
        }
        {
            decimal? input = -1E-28m;
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(0), "nullable-decimal-byte-explicit-unchecked-lift-8");
        }
        {
            decimal? input = 254m;
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(254), "nullable-decimal-byte-explicit-unchecked-lift-9");
        }
        {
            decimal? input = 255m;
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(255), "nullable-decimal-byte-explicit-unchecked-lift-10");
        }
        {
            decimal? input = -0.75m;
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(0), "nullable-decimal-byte-explicit-unchecked-lift-12");
        }
        {
            decimal? input = 255.75m;
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(255), "nullable-decimal-byte-explicit-unchecked-lift-13");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
