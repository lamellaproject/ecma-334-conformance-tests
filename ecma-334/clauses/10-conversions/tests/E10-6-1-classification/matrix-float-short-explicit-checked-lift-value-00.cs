/*
Rules: E10-6-1-classification; E10-6-1-nonnull
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 12
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
            float? input = 0.0f;
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(0), "nullable-float-short-explicit-checked-lift-2");
        }
        {
            float? input = -0.0f;
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(0), "nullable-float-short-explicit-checked-lift-3");
        }
        {
            float? input = 1.0f;
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(1), "nullable-float-short-explicit-checked-lift-4");
        }
        {
            float? input = -1.0f;
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(-1), "nullable-float-short-explicit-checked-lift-5");
        }
        {
            float? input = 0.75f;
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(0), "nullable-float-short-explicit-checked-lift-6");
        }
        {
            float? input = -0.75f;
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(0), "nullable-float-short-explicit-checked-lift-7");
        }
        {
            float? input = -32768.0f;
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(-32768), "nullable-float-short-explicit-checked-lift-12");
        }
        {
            float? input = -32767.0f;
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(-32767), "nullable-float-short-explicit-checked-lift-13");
        }
        {
            float? input = 32766.0f;
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(32766), "nullable-float-short-explicit-checked-lift-14");
        }
        {
            float? input = 32767.0f;
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(32767), "nullable-float-short-explicit-checked-lift-15");
        }
        {
            float? input = -32768.75f;
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(-32768), "nullable-float-short-explicit-checked-lift-17");
        }
        {
            float? input = 32767.75f;
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(32767), "nullable-float-short-explicit-checked-lift-18");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
