/*
Rules: E10-2-3-long; E12-23-numeric
Authority: ECMA-334 7th ed 10.2.3
Version: 7.3
Expected: run
Stdout: OK 11
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
            const long input = long.MinValue;
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14114281232179134464UL, "long-double-implicit-unchecked-constant-0");
        }
        {
            const long input = 9223372036854775807L;
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4890909195324358656UL, "long-double-implicit-unchecked-constant-1");
        }
        {
            const long input = 0L;
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==0UL, "long-double-implicit-unchecked-constant-2");
        }
        {
            const long input = 1L;
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4607182418800017408UL, "long-double-implicit-unchecked-constant-3");
        }
        {
            const long input = -1L;
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==13830554455654793216UL, "long-double-implicit-unchecked-constant-4");
        }
        {
            const long input = 9007199254740991L;
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653695UL, "long-double-implicit-unchecked-constant-5");
        }
        {
            const long input = 9007199254740992L;
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653696UL, "long-double-implicit-unchecked-constant-6");
        }
        {
            const long input = 9007199254740993L;
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653696UL, "long-double-implicit-unchecked-constant-7");
        }
        {
            const long input = -9007199254740993L;
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14069245235905429504UL, "long-double-implicit-unchecked-constant-8");
        }
        {
            const long input = -9007199254740992L;
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14069245235905429504UL, "long-double-implicit-unchecked-constant-9");
        }
        {
            const long input = -9007199254740991L;
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14069245235905429503UL, "long-double-implicit-unchecked-constant-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
