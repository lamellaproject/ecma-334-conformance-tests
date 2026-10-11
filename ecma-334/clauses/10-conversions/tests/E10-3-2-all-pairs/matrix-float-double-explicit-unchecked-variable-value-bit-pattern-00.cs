/*
Rules: E10-3-2-all-pairs; E10-3-2-float
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 10
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
            float input = -3.40282347e+38f;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14407015207421345792UL, "float-double-explicit-unchecked-variable-0");
        }
        {
            float input = 3.40282347e+38f;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==5183643170566569984UL, "float-double-explicit-unchecked-variable-1");
        }
        {
            float input = 0.0f;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==0UL, "float-double-explicit-unchecked-variable-2");
        }
        {
            float input = -0.0f;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==9223372036854775808UL, "float-double-explicit-unchecked-variable-3");
        }
        {
            float input = 1.0f;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4607182418800017408UL, "float-double-explicit-unchecked-variable-4");
        }
        {
            float input = -1.0f;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==13830554455654793216UL, "float-double-explicit-unchecked-variable-5");
        }
        {
            float input = 0.75f;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4604930618986332160UL, "float-double-explicit-unchecked-variable-6");
        }
        {
            float input = -0.75f;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==13828302655841107968UL, "float-double-explicit-unchecked-variable-7");
        }
        {
            float input = 9.00719925e+15f;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653696UL, "float-double-explicit-unchecked-variable-11");
        }
        {
            float input = -9.00719925e+15f;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14069245235905429504UL, "float-double-explicit-unchecked-variable-12");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
