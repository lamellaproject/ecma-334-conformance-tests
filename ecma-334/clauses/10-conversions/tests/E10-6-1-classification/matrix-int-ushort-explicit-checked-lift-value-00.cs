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
            int? input = 0;
            ushort? result = checked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(0), "nullable-int-ushort-explicit-checked-lift-2");
        }
        {
            int? input = 1;
            ushort? result = checked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(1), "nullable-int-ushort-explicit-checked-lift-3");
        }
        {
            int? input = 65534;
            ushort? result = checked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(65534), "nullable-int-ushort-explicit-checked-lift-5");
        }
        {
            int? input = 65535;
            ushort? result = checked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(65535), "nullable-int-ushort-explicit-checked-lift-6");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
