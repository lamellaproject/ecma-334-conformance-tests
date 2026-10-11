/*
Rules: E10-3-2-all-pairs; E10-3-2-ulong; E12-23-numeric
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 6
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
            const ulong input = 0UL;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==0UL, "ulong-double-explicit-checked-constant-0");
        }
        {
            const ulong input = 18446744073709551615UL;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4895412794951729152UL, "ulong-double-explicit-checked-constant-1");
        }
        {
            const ulong input = 1UL;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4607182418800017408UL, "ulong-double-explicit-checked-constant-2");
        }
        {
            const ulong input = 9007199254740991UL;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653695UL, "ulong-double-explicit-checked-constant-3");
        }
        {
            const ulong input = 9007199254740992UL;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653696UL, "ulong-double-explicit-checked-constant-4");
        }
        {
            const ulong input = 9007199254740993UL;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653696UL, "ulong-double-explicit-checked-constant-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
