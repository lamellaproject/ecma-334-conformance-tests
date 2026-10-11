/*
Rules: E10-3-2-all-pairs; E10-3-2-decimal
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 15
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
            decimal input = -79228162514264337593543950335m;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14262900019882360832UL, "decimal-double-explicit-unchecked-variable-0");
        }
        {
            decimal input = 79228162514264337593543950335m;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==5039527983027585024UL, "decimal-double-explicit-unchecked-variable-1");
        }
        {
            decimal input = 0m;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==0UL, "decimal-double-explicit-unchecked-variable-2");
        }
        {
            decimal input = 1m;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4607182418800017408UL, "decimal-double-explicit-unchecked-variable-3");
        }
        {
            decimal input = -1m;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==13830554455654793216UL, "decimal-double-explicit-unchecked-variable-4");
        }
        {
            decimal input = 0.1m;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4591870180066957722UL, "decimal-double-explicit-unchecked-variable-5");
        }
        {
            decimal input = -0.1m;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==13815242216921733530UL, "decimal-double-explicit-unchecked-variable-6");
        }
        {
            decimal input = 1E-28m;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4188260752279232537UL, "decimal-double-explicit-unchecked-variable-7");
        }
        {
            decimal input = -1E-28m;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==13411632789134008345UL, "decimal-double-explicit-unchecked-variable-8");
        }
        {
            decimal input = 9007199254740991m;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653695UL, "decimal-double-explicit-unchecked-variable-9");
        }
        {
            decimal input = 9007199254740992m;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653696UL, "decimal-double-explicit-unchecked-variable-10");
        }
        {
            decimal input = 9007199254740993m;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653696UL, "decimal-double-explicit-unchecked-variable-11");
        }
        {
            decimal input = -9007199254740993m;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14069245235905429504UL, "decimal-double-explicit-unchecked-variable-12");
        }
        {
            decimal input = -9007199254740992m;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14069245235905429504UL, "decimal-double-explicit-unchecked-variable-13");
        }
        {
            decimal input = -9007199254740991m;
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14069245235905429503UL, "decimal-double-explicit-unchecked-variable-14");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
