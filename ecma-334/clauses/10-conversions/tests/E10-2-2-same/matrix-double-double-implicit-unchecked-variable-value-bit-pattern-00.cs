/*
Rules: E10-2-2-same
Authority: ECMA-334 7th ed 10.2.2
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
            double input = -1.7976931348623157e+308d;
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==18442240474082181119UL, "double-double-implicit-unchecked-variable-0");
        }
        {
            double input = 1.7976931348623157e+308d;
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==9218868437227405311UL, "double-double-implicit-unchecked-variable-1");
        }
        {
            double input = 0.0d;
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==0UL, "double-double-implicit-unchecked-variable-2");
        }
        {
            double input = -0.0d;
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==9223372036854775808UL, "double-double-implicit-unchecked-variable-3");
        }
        {
            double input = 1.0d;
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4607182418800017408UL, "double-double-implicit-unchecked-variable-4");
        }
        {
            double input = -1.0d;
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==13830554455654793216UL, "double-double-implicit-unchecked-variable-5");
        }
        {
            double input = 0.75d;
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4604930618986332160UL, "double-double-implicit-unchecked-variable-6");
        }
        {
            double input = -0.75d;
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==13828302655841107968UL, "double-double-implicit-unchecked-variable-7");
        }
        {
            double input = 9007199254740991.0d;
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653695UL, "double-double-implicit-unchecked-variable-11");
        }
        {
            double input = 9007199254740992.0d;
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653696UL, "double-double-implicit-unchecked-variable-12");
        }
        {
            double input = -9007199254740992.0d;
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14069245235905429504UL, "double-double-implicit-unchecked-variable-13");
        }
        {
            double input = -9007199254740991.0d;
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14069245235905429503UL, "double-double-implicit-unchecked-variable-14");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
