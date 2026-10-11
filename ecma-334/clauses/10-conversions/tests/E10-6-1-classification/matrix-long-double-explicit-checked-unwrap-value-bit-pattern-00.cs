/*
Rules: E10-6-1-classification; E10-6-1-unwrap
Authority: ECMA-334 7th ed 10.6.1
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
            long? input = long.MinValue;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14114281232179134464UL, "nullable-long-double-explicit-checked-unwrap-0");
        }
        {
            long? input = 9223372036854775807L;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4890909195324358656UL, "nullable-long-double-explicit-checked-unwrap-1");
        }
        {
            long? input = 0L;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==0UL, "nullable-long-double-explicit-checked-unwrap-2");
        }
        {
            long? input = 1L;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4607182418800017408UL, "nullable-long-double-explicit-checked-unwrap-3");
        }
        {
            long? input = -1L;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==13830554455654793216UL, "nullable-long-double-explicit-checked-unwrap-4");
        }
        {
            long? input = 9007199254740991L;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653695UL, "nullable-long-double-explicit-checked-unwrap-5");
        }
        {
            long? input = 9007199254740992L;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653696UL, "nullable-long-double-explicit-checked-unwrap-6");
        }
        {
            long? input = 9007199254740993L;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653696UL, "nullable-long-double-explicit-checked-unwrap-7");
        }
        {
            long? input = -9007199254740993L;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14069245235905429504UL, "nullable-long-double-explicit-checked-unwrap-8");
        }
        {
            long? input = -9007199254740992L;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14069245235905429504UL, "nullable-long-double-explicit-checked-unwrap-9");
        }
        {
            long? input = -9007199254740991L;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14069245235905429503UL, "nullable-long-double-explicit-checked-unwrap-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
