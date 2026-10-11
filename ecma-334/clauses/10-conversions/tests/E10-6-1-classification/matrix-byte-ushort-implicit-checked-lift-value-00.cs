/*
Rules: E10-6-1-classification; E10-6-1-nonnull
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 3
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
            byte? input = (byte)(0);
            ushort? result = checked(input);
            Check(result.HasValue && result.Value==(ushort)(0), "nullable-byte-ushort-implicit-checked-lift-0");
        }
        {
            byte? input = (byte)(255);
            ushort? result = checked(input);
            Check(result.HasValue && result.Value==(ushort)(255), "nullable-byte-ushort-implicit-checked-lift-1");
        }
        {
            byte? input = (byte)(1);
            ushort? result = checked(input);
            Check(result.HasValue && result.Value==(ushort)(1), "nullable-byte-ushort-implicit-checked-lift-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
