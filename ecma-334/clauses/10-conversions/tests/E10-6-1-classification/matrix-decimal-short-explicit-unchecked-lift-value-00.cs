/*
Rules: E10-6-1-classification; E10-6-1-nonnull
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 13
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
            short? result = unchecked((short?)input);
            Check(result.HasValue && result.Value==(short)(0), "nullable-decimal-short-explicit-unchecked-lift-2");
        }
        {
            decimal? input = 1m;
            short? result = unchecked((short?)input);
            Check(result.HasValue && result.Value==(short)(1), "nullable-decimal-short-explicit-unchecked-lift-3");
        }
        {
            decimal? input = -1m;
            short? result = unchecked((short?)input);
            Check(result.HasValue && result.Value==(short)(-1), "nullable-decimal-short-explicit-unchecked-lift-4");
        }
        {
            decimal? input = 0.1m;
            short? result = unchecked((short?)input);
            Check(result.HasValue && result.Value==(short)(0), "nullable-decimal-short-explicit-unchecked-lift-5");
        }
        {
            decimal? input = -0.1m;
            short? result = unchecked((short?)input);
            Check(result.HasValue && result.Value==(short)(0), "nullable-decimal-short-explicit-unchecked-lift-6");
        }
        {
            decimal? input = 1E-28m;
            short? result = unchecked((short?)input);
            Check(result.HasValue && result.Value==(short)(0), "nullable-decimal-short-explicit-unchecked-lift-7");
        }
        {
            decimal? input = -1E-28m;
            short? result = unchecked((short?)input);
            Check(result.HasValue && result.Value==(short)(0), "nullable-decimal-short-explicit-unchecked-lift-8");
        }
        {
            decimal? input = -32768m;
            short? result = unchecked((short?)input);
            Check(result.HasValue && result.Value==(short)(-32768), "nullable-decimal-short-explicit-unchecked-lift-10");
        }
        {
            decimal? input = -32767m;
            short? result = unchecked((short?)input);
            Check(result.HasValue && result.Value==(short)(-32767), "nullable-decimal-short-explicit-unchecked-lift-11");
        }
        {
            decimal? input = 32766m;
            short? result = unchecked((short?)input);
            Check(result.HasValue && result.Value==(short)(32766), "nullable-decimal-short-explicit-unchecked-lift-12");
        }
        {
            decimal? input = 32767m;
            short? result = unchecked((short?)input);
            Check(result.HasValue && result.Value==(short)(32767), "nullable-decimal-short-explicit-unchecked-lift-13");
        }
        {
            decimal? input = -32768.75m;
            short? result = unchecked((short?)input);
            Check(result.HasValue && result.Value==(short)(-32768), "nullable-decimal-short-explicit-unchecked-lift-15");
        }
        {
            decimal? input = 32767.75m;
            short? result = unchecked((short?)input);
            Check(result.HasValue && result.Value==(short)(32767), "nullable-decimal-short-explicit-unchecked-lift-16");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
