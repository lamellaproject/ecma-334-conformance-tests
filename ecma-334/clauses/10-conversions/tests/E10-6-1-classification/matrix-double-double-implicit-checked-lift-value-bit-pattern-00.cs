/*
Rules: E10-6-1-classification; E10-6-1-nonnull
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 12
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
            double? input = -1.7976931348623157e+308d;
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==18442240474082181119UL, "nullable-double-double-implicit-checked-lift-0");
        }
        {
            double? input = 1.7976931348623157e+308d;
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==9218868437227405311UL, "nullable-double-double-implicit-checked-lift-1");
        }
        {
            double? input = 0.0d;
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==0UL, "nullable-double-double-implicit-checked-lift-2");
        }
        {
            double? input = -0.0d;
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==9223372036854775808UL, "nullable-double-double-implicit-checked-lift-3");
        }
        {
            double? input = 1.0d;
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4607182418800017408UL, "nullable-double-double-implicit-checked-lift-4");
        }
        {
            double? input = -1.0d;
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==13830554455654793216UL, "nullable-double-double-implicit-checked-lift-5");
        }
        {
            double? input = 0.75d;
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4604930618986332160UL, "nullable-double-double-implicit-checked-lift-6");
        }
        {
            double? input = -0.75d;
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==13828302655841107968UL, "nullable-double-double-implicit-checked-lift-7");
        }
        {
            double? input = 9007199254740991.0d;
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4845873199050653695UL, "nullable-double-double-implicit-checked-lift-11");
        }
        {
            double? input = 9007199254740992.0d;
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==4845873199050653696UL, "nullable-double-double-implicit-checked-lift-12");
        }
        {
            double? input = -9007199254740992.0d;
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==14069245235905429504UL, "nullable-double-double-implicit-checked-lift-13");
        }
        {
            double? input = -9007199254740991.0d;
            double? result = checked(input);
            Check(result.HasValue && unchecked((ulong)BitConverter.DoubleToInt64Bits(result.Value))==14069245235905429503UL, "nullable-double-double-implicit-checked-lift-14");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
