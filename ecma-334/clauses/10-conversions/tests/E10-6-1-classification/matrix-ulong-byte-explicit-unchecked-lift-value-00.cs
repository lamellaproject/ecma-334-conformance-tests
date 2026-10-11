/*
Rules: E10-6-1-classification; E10-6-1-nonnull
Authority: ECMA-334 7th ed 10.6.1
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
            ulong? input = 0UL;
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(0), "nullable-ulong-byte-explicit-unchecked-lift-0");
        }
        {
            ulong? input = 18446744073709551615UL;
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(255), "nullable-ulong-byte-explicit-unchecked-lift-1");
        }
        {
            ulong? input = 1UL;
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(1), "nullable-ulong-byte-explicit-unchecked-lift-2");
        }
        {
            ulong? input = 254UL;
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(254), "nullable-ulong-byte-explicit-unchecked-lift-3");
        }
        {
            ulong? input = 255UL;
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(255), "nullable-ulong-byte-explicit-unchecked-lift-4");
        }
        {
            ulong? input = 256UL;
            byte? result = unchecked((byte?)input);
            Check(result.HasValue && result.Value==(byte)(0), "nullable-ulong-byte-explicit-unchecked-lift-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
