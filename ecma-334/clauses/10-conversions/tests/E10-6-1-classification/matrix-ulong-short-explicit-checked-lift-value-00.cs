/*
Rules: E10-6-1-classification; E10-6-1-nonnull
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
            ulong? input = 0UL;
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(0), "nullable-ulong-short-explicit-checked-lift-0");
        }
        {
            ulong? input = 1UL;
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(1), "nullable-ulong-short-explicit-checked-lift-2");
        }
        {
            ulong? input = 32766UL;
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(32766), "nullable-ulong-short-explicit-checked-lift-3");
        }
        {
            ulong? input = 32767UL;
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(32767), "nullable-ulong-short-explicit-checked-lift-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
