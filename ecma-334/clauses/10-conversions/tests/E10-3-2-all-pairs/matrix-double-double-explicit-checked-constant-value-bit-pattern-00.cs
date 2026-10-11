/*
Rules: E10-3-2-all-pairs; E12-23-numeric
Authority: ECMA-334 7th ed 10.3.2
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
            const double input = -1.7976931348623157e+308d;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==18442240474082181119UL, "double-double-explicit-checked-constant-0");
        }
        {
            const double input = 1.7976931348623157e+308d;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==9218868437227405311UL, "double-double-explicit-checked-constant-1");
        }
        {
            const double input = 0.0d;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==0UL, "double-double-explicit-checked-constant-2");
        }
        {
            const double input = -0.0d;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==9223372036854775808UL, "double-double-explicit-checked-constant-3");
        }
        {
            const double input = 1.0d;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4607182418800017408UL, "double-double-explicit-checked-constant-4");
        }
        {
            const double input = -1.0d;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==13830554455654793216UL, "double-double-explicit-checked-constant-5");
        }
        {
            const double input = 0.75d;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4604930618986332160UL, "double-double-explicit-checked-constant-6");
        }
        {
            const double input = -0.75d;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==13828302655841107968UL, "double-double-explicit-checked-constant-7");
        }
        {
            const double input = 9007199254740991.0d;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653695UL, "double-double-explicit-checked-constant-11");
        }
        {
            const double input = 9007199254740992.0d;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653696UL, "double-double-explicit-checked-constant-12");
        }
        {
            const double input = -9007199254740992.0d;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14069245235905429504UL, "double-double-explicit-checked-constant-13");
        }
        {
            const double input = -9007199254740991.0d;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14069245235905429503UL, "double-double-explicit-checked-constant-14");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
