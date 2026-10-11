/*
Rules: E10-6-1-classification; E10-6-1-unwrap
Authority: ECMA-334 7th ed 10.6.1
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
            decimal? input = -79228162514264337593543950335m;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14262900019882360832UL, "nullable-decimal-double-explicit-checked-unwrap-0");
        }
        {
            decimal? input = 79228162514264337593543950335m;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==5039527983027585024UL, "nullable-decimal-double-explicit-checked-unwrap-1");
        }
        {
            decimal? input = 0m;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==0UL, "nullable-decimal-double-explicit-checked-unwrap-2");
        }
        {
            decimal? input = 1m;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4607182418800017408UL, "nullable-decimal-double-explicit-checked-unwrap-3");
        }
        {
            decimal? input = -1m;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==13830554455654793216UL, "nullable-decimal-double-explicit-checked-unwrap-4");
        }
        {
            decimal? input = 0.1m;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4591870180066957722UL, "nullable-decimal-double-explicit-checked-unwrap-5");
        }
        {
            decimal? input = -0.1m;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==13815242216921733530UL, "nullable-decimal-double-explicit-checked-unwrap-6");
        }
        {
            decimal? input = 1E-28m;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4188260752279232537UL, "nullable-decimal-double-explicit-checked-unwrap-7");
        }
        {
            decimal? input = -1E-28m;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==13411632789134008345UL, "nullable-decimal-double-explicit-checked-unwrap-8");
        }
        {
            decimal? input = 9007199254740991m;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653695UL, "nullable-decimal-double-explicit-checked-unwrap-9");
        }
        {
            decimal? input = 9007199254740992m;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653696UL, "nullable-decimal-double-explicit-checked-unwrap-10");
        }
        {
            decimal? input = 9007199254740993m;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653696UL, "nullable-decimal-double-explicit-checked-unwrap-11");
        }
        {
            decimal? input = -9007199254740993m;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14069245235905429504UL, "nullable-decimal-double-explicit-checked-unwrap-12");
        }
        {
            decimal? input = -9007199254740992m;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14069245235905429504UL, "nullable-decimal-double-explicit-checked-unwrap-13");
        }
        {
            decimal? input = -9007199254740991m;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14069245235905429503UL, "nullable-decimal-double-explicit-checked-unwrap-14");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
