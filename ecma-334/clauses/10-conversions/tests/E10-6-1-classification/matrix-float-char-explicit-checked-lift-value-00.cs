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
            float? input = 0.0f;
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(0), "nullable-float-char-explicit-checked-lift-2");
        }
        {
            float? input = -0.0f;
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(0), "nullable-float-char-explicit-checked-lift-3");
        }
        {
            float? input = 1.0f;
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(1), "nullable-float-char-explicit-checked-lift-4");
        }
        {
            float? input = 0.75f;
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(0), "nullable-float-char-explicit-checked-lift-6");
        }
        {
            float? input = -0.75f;
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(0), "nullable-float-char-explicit-checked-lift-7");
        }
        {
            float? input = 65534.0f;
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(65534), "nullable-float-char-explicit-checked-lift-11");
        }
        {
            float? input = 65535.0f;
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(65535), "nullable-float-char-explicit-checked-lift-12");
        }
        {
            float? input = 65535.75f;
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(65535), "nullable-float-char-explicit-checked-lift-14");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
