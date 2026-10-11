/*
Rules: E10-3-2-all-pairs; E10-3-2-long
Authority: ECMA-334 7th ed 10.3.2
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
            long input = long.MinValue;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14114281232179134464UL, "long-double-explicit-checked-variable-0");
        }
        {
            long input = 9223372036854775807L;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4890909195324358656UL, "long-double-explicit-checked-variable-1");
        }
        {
            long input = 0L;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==0UL, "long-double-explicit-checked-variable-2");
        }
        {
            long input = 1L;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4607182418800017408UL, "long-double-explicit-checked-variable-3");
        }
        {
            long input = -1L;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==13830554455654793216UL, "long-double-explicit-checked-variable-4");
        }
        {
            long input = 9007199254740991L;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653695UL, "long-double-explicit-checked-variable-5");
        }
        {
            long input = 9007199254740992L;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653696UL, "long-double-explicit-checked-variable-6");
        }
        {
            long input = 9007199254740993L;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653696UL, "long-double-explicit-checked-variable-7");
        }
        {
            long input = -9007199254740993L;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14069245235905429504UL, "long-double-explicit-checked-variable-8");
        }
        {
            long input = -9007199254740992L;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14069245235905429504UL, "long-double-explicit-checked-variable-9");
        }
        {
            long input = -9007199254740991L;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14069245235905429503UL, "long-double-explicit-checked-variable-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
