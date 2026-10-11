/*
Rules: E10-2-3-sbyte; E12-23-numeric
Authority: ECMA-334 7th ed 10.2.3
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
            const sbyte input = (sbyte)(-128);
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==13862079653046386688UL, "sbyte-double-implicit-unchecked-constant-0");
        }
        {
            const sbyte input = (sbyte)(127);
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4638637247447433216UL, "sbyte-double-implicit-unchecked-constant-1");
        }
        {
            const sbyte input = (sbyte)(0);
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==0UL, "sbyte-double-implicit-unchecked-constant-2");
        }
        {
            const sbyte input = (sbyte)(1);
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4607182418800017408UL, "sbyte-double-implicit-unchecked-constant-3");
        }
        {
            const sbyte input = (sbyte)(-1);
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==13830554455654793216UL, "sbyte-double-implicit-unchecked-constant-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
