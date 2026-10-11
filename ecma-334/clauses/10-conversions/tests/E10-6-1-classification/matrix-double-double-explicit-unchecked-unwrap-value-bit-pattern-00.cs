/*
Rules: E10-6-1-classification; E10-6-1-unwrap
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
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==18442240474082181119UL, "nullable-double-double-explicit-unchecked-unwrap-0");
        }
        {
            double? input = 1.7976931348623157e+308d;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==9218868437227405311UL, "nullable-double-double-explicit-unchecked-unwrap-1");
        }
        {
            double? input = 0.0d;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==0UL, "nullable-double-double-explicit-unchecked-unwrap-2");
        }
        {
            double? input = -0.0d;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==9223372036854775808UL, "nullable-double-double-explicit-unchecked-unwrap-3");
        }
        {
            double? input = 1.0d;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4607182418800017408UL, "nullable-double-double-explicit-unchecked-unwrap-4");
        }
        {
            double? input = -1.0d;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==13830554455654793216UL, "nullable-double-double-explicit-unchecked-unwrap-5");
        }
        {
            double? input = 0.75d;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4604930618986332160UL, "nullable-double-double-explicit-unchecked-unwrap-6");
        }
        {
            double? input = -0.75d;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==13828302655841107968UL, "nullable-double-double-explicit-unchecked-unwrap-7");
        }
        {
            double? input = 9007199254740991.0d;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653695UL, "nullable-double-double-explicit-unchecked-unwrap-11");
        }
        {
            double? input = 9007199254740992.0d;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653696UL, "nullable-double-double-explicit-unchecked-unwrap-12");
        }
        {
            double? input = -9007199254740992.0d;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14069245235905429504UL, "nullable-double-double-explicit-unchecked-unwrap-13");
        }
        {
            double? input = -9007199254740991.0d;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14069245235905429503UL, "nullable-double-double-explicit-unchecked-unwrap-14");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
