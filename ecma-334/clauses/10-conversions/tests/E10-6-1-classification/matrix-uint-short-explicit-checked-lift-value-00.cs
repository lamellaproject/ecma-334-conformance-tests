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
            uint? input = 0U;
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(0), "nullable-uint-short-explicit-checked-lift-0");
        }
        {
            uint? input = 1U;
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(1), "nullable-uint-short-explicit-checked-lift-2");
        }
        {
            uint? input = 32766U;
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(32766), "nullable-uint-short-explicit-checked-lift-3");
        }
        {
            uint? input = 32767U;
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(32767), "nullable-uint-short-explicit-checked-lift-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
