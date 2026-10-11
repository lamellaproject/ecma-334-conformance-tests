/*
Rules: E10-6-1-classification; E10-6-1-nonnull
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 5
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
            ushort? result = unchecked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(32768), "nullable-short-ushort-explicit-unchecked-lift-0");
        }
        {
            short? input = (short)(32767);
            ushort? result = unchecked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(32767), "nullable-short-ushort-explicit-unchecked-lift-1");
        }
        {
            short? input = (short)(0);
            ushort? result = unchecked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(0), "nullable-short-ushort-explicit-unchecked-lift-2");
        }
        {
            short? input = (short)(1);
            ushort? result = unchecked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(1), "nullable-short-ushort-explicit-unchecked-lift-3");
        }
        {
            short? input = (short)(-1);
            ushort? result = unchecked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(65535), "nullable-short-ushort-explicit-unchecked-lift-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
