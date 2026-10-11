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
            sbyte? input = (sbyte)(-128);
            short? result = checked(input);
            Check(result.HasValue && result.Value==(short)(-128), "nullable-sbyte-short-implicit-checked-lift-0");
        }
        {
            sbyte? input = (sbyte)(127);
            short? result = checked(input);
            Check(result.HasValue && result.Value==(short)(127), "nullable-sbyte-short-implicit-checked-lift-1");
        }
        {
            sbyte? input = (sbyte)(0);
            short? result = checked(input);
            Check(result.HasValue && result.Value==(short)(0), "nullable-sbyte-short-implicit-checked-lift-2");
        }
        {
            sbyte? input = (sbyte)(1);
            short? result = checked(input);
            Check(result.HasValue && result.Value==(short)(1), "nullable-sbyte-short-implicit-checked-lift-3");
        }
        {
            sbyte? input = (sbyte)(-1);
            short? result = checked(input);
            Check(result.HasValue && result.Value==(short)(-1), "nullable-sbyte-short-implicit-checked-lift-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
