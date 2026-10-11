/*
Rules: E10-6-1-classification; E10-6-1-nonnull
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 6
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
            ulong? input = 0UL;
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==0UL, "nullable-ulong-double-implicit-checked-lift-0");
        }
        {
            ulong? input = 18446744073709551615UL;
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4895412794951729152UL, "nullable-ulong-double-implicit-checked-lift-1");
        }
        {
            ulong? input = 1UL;
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4607182418800017408UL, "nullable-ulong-double-implicit-checked-lift-2");
        }
        {
            ulong? input = 9007199254740991UL;
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4845873199050653695UL, "nullable-ulong-double-implicit-checked-lift-3");
        }
        {
            ulong? input = 9007199254740992UL;
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4845873199050653696UL, "nullable-ulong-double-implicit-checked-lift-4");
        }
        {
            ulong? input = 9007199254740993UL;
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4845873199050653696UL, "nullable-ulong-double-implicit-checked-lift-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
