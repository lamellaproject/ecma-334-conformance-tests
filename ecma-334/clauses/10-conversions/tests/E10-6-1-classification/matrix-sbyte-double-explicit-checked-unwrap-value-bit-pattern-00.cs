/*
Rules: E10-6-1-classification; E10-6-1-unwrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 5
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
            sbyte? input = (sbyte)(-128);
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==13862079653046386688UL, "nullable-sbyte-double-explicit-checked-unwrap-0");
        }
        {
            sbyte? input = (sbyte)(127);
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4638637247447433216UL, "nullable-sbyte-double-explicit-checked-unwrap-1");
        }
        {
            sbyte? input = (sbyte)(0);
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==0UL, "nullable-sbyte-double-explicit-checked-unwrap-2");
        }
        {
            sbyte? input = (sbyte)(1);
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4607182418800017408UL, "nullable-sbyte-double-explicit-checked-unwrap-3");
        }
        {
            sbyte? input = (sbyte)(-1);
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==13830554455654793216UL, "nullable-sbyte-double-explicit-checked-unwrap-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
