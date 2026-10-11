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
            int? input = -2147483648;
            ushort? result = unchecked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(0), "nullable-int-ushort-explicit-unchecked-lift-0");
        }
        {
            int? input = 2147483647;
            ushort? result = unchecked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(65535), "nullable-int-ushort-explicit-unchecked-lift-1");
        }
        {
            int? input = 0;
            ushort? result = unchecked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(0), "nullable-int-ushort-explicit-unchecked-lift-2");
        }
        {
            int? input = 1;
            ushort? result = unchecked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(1), "nullable-int-ushort-explicit-unchecked-lift-3");
        }
        {
            int? input = -1;
            ushort? result = unchecked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(65535), "nullable-int-ushort-explicit-unchecked-lift-4");
        }
        {
            int? input = 65534;
            ushort? result = unchecked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(65534), "nullable-int-ushort-explicit-unchecked-lift-5");
        }
        {
            int? input = 65535;
            ushort? result = unchecked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(65535), "nullable-int-ushort-explicit-unchecked-lift-6");
        }
        {
            int? input = 65536;
            ushort? result = unchecked((ushort?)input);
            Check(result.HasValue && result.Value==(ushort)(0), "nullable-int-ushort-explicit-unchecked-lift-7");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
