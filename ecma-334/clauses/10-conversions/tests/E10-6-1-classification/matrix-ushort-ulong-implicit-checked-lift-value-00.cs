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
            ushort? input = (ushort)(0);
            ulong? result = checked(input);
            Check(result.HasValue && result.Value==0UL, "nullable-ushort-ulong-implicit-checked-lift-0");
        }
        {
            ushort? input = (ushort)(65535);
            ulong? result = checked(input);
            Check(result.HasValue && result.Value==65535UL, "nullable-ushort-ulong-implicit-checked-lift-1");
        }
        {
            ushort? input = (ushort)(1);
            ulong? result = checked(input);
            Check(result.HasValue && result.Value==1UL, "nullable-ushort-ulong-implicit-checked-lift-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
