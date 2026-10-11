/*
Rules: E10-6-1-classification; E10-6-1-wrap
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
            ushort input = (ushort)(0);
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(0), "nullable-ushort-short-explicit-checked-wrap-0");
        }
        {
            ushort input = (ushort)(1);
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(1), "nullable-ushort-short-explicit-checked-wrap-2");
        }
        {
            ushort input = (ushort)(32766);
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(32766), "nullable-ushort-short-explicit-checked-wrap-3");
        }
        {
            ushort input = (ushort)(32767);
            short? result = checked((short?)input);
            Check(result.HasValue && result.Value==(short)(32767), "nullable-ushort-short-explicit-checked-wrap-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
