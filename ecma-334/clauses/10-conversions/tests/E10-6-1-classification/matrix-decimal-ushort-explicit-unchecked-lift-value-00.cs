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
            ushort? result = unchecked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(0), "nullable-decimal-ushort-explicit-unchecked-lift-2");
        }
        {
            decimal? input = 1m;
            ushort? result = unchecked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(1), "nullable-decimal-ushort-explicit-unchecked-lift-3");
        }
        {
            decimal? input = 0.1m;
            ushort? result = unchecked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(0), "nullable-decimal-ushort-explicit-unchecked-lift-5");
        }
        {
            decimal? input = -0.1m;
            ushort? result = unchecked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(0), "nullable-decimal-ushort-explicit-unchecked-lift-6");
        }
        {
            decimal? input = 1E-28m;
            ushort? result = unchecked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(0), "nullable-decimal-ushort-explicit-unchecked-lift-7");
        }
        {
            decimal? input = -1E-28m;
            ushort? result = unchecked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(0), "nullable-decimal-ushort-explicit-unchecked-lift-8");
        }
        {
            decimal? input = 65534m;
            ushort? result = unchecked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(65534), "nullable-decimal-ushort-explicit-unchecked-lift-9");
        }
        {
            decimal? input = 65535m;
            ushort? result = unchecked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(65535), "nullable-decimal-ushort-explicit-unchecked-lift-10");
        }
        {
            decimal? input = -0.75m;
            ushort? result = unchecked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(0), "nullable-decimal-ushort-explicit-unchecked-lift-12");
        }
        {
            decimal? input = 65535.75m;
            ushort? result = unchecked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(65535), "nullable-decimal-ushort-explicit-unchecked-lift-13");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
