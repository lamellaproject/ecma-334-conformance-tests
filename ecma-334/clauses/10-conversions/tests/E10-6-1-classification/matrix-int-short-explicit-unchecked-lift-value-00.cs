/*
Rules: E10-6-1-classification; E10-6-1-nonnull
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 11
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
            int? input = -2147483648;
            short? result = unchecked((short?)input);
            Check(result.HasValue && result.Value==(short)(0), "nullable-int-short-explicit-unchecked-lift-0");
        }
        {
            int? input = 2147483647;
            short? result = unchecked((short?)input);
            Check(result.HasValue && result.Value==(short)(-1), "nullable-int-short-explicit-unchecked-lift-1");
        }
        {
            int? input = 0;
            short? result = unchecked((short?)input);
            Check(result.HasValue && result.Value==(short)(0), "nullable-int-short-explicit-unchecked-lift-2");
        }
        {
            int? input = 1;
            short? result = unchecked((short?)input);
            Check(result.HasValue && result.Value==(short)(1), "nullable-int-short-explicit-unchecked-lift-3");
        }
        {
            int? input = -1;
            short? result = unchecked((short?)input);
            Check(result.HasValue && result.Value==(short)(-1), "nullable-int-short-explicit-unchecked-lift-4");
        }
        {
            int? input = -32769;
            short? result = unchecked((short?)input);
            Check(result.HasValue && result.Value==(short)(32767), "nullable-int-short-explicit-unchecked-lift-5");
        }
        {
            int? input = -32768;
            short? result = unchecked((short?)input);
            Check(result.HasValue && result.Value==(short)(-32768), "nullable-int-short-explicit-unchecked-lift-6");
        }
        {
            int? input = -32767;
            short? result = unchecked((short?)input);
            Check(result.HasValue && result.Value==(short)(-32767), "nullable-int-short-explicit-unchecked-lift-7");
        }
        {
            int? input = 32766;
            short? result = unchecked((short?)input);
            Check(result.HasValue && result.Value==(short)(32766), "nullable-int-short-explicit-unchecked-lift-8");
        }
        {
            int? input = 32767;
            short? result = unchecked((short?)input);
            Check(result.HasValue && result.Value==(short)(32767), "nullable-int-short-explicit-unchecked-lift-9");
        }
        {
            int? input = 32768;
            short? result = unchecked((short?)input);
            Check(result.HasValue && result.Value==(short)(-32768), "nullable-int-short-explicit-unchecked-lift-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
