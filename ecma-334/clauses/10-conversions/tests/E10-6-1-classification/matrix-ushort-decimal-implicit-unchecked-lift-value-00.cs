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
            decimal? result = unchecked(input);
            Check(result.HasValue && result.Value==0m, "nullable-ushort-decimal-implicit-unchecked-lift-0");
        }
        {
            ushort? input = (ushort)(65535);
            decimal? result = unchecked(input);
            Check(result.HasValue && result.Value==65535m, "nullable-ushort-decimal-implicit-unchecked-lift-1");
        }
        {
            ushort? input = (ushort)(1);
            decimal? result = unchecked(input);
            Check(result.HasValue && result.Value==1m, "nullable-ushort-decimal-implicit-unchecked-lift-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
