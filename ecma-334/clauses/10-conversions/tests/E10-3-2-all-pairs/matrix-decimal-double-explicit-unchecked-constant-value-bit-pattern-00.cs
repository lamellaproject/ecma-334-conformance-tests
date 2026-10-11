/*
Rules: E10-3-2-all-pairs; E10-3-2-decimal; E12-23-numeric
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 8
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
            const decimal input = 79228162514264337593543950335m;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==5039527983027585024UL, "decimal-double-explicit-unchecked-constant-1");
        }
        {
            const decimal input = 0m;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==0UL, "decimal-double-explicit-unchecked-constant-2");
        }
        {
            const decimal input = 1m;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4607182418800017408UL, "decimal-double-explicit-unchecked-constant-3");
        }
        {
            const decimal input = 0.1m;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4591870180066957722UL, "decimal-double-explicit-unchecked-constant-5");
        }
        {
            const decimal input = 1E-28m;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4188260752279232537UL, "decimal-double-explicit-unchecked-constant-7");
        }
        {
            const decimal input = 9007199254740991m;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653695UL, "decimal-double-explicit-unchecked-constant-9");
        }
        {
            const decimal input = 9007199254740992m;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653696UL, "decimal-double-explicit-unchecked-constant-10");
        }
        {
            const decimal input = 9007199254740993m;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653696UL, "decimal-double-explicit-unchecked-constant-11");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
