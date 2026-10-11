/*
Rules: E10-2-3-ulong
Authority: ECMA-334 7th ed 10.2.3
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
            ulong input = 0UL;
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==0UL, "ulong-double-implicit-unchecked-variable-0");
        }
        {
            ulong input = 18446744073709551615UL;
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4895412794951729152UL, "ulong-double-implicit-unchecked-variable-1");
        }
        {
            ulong input = 1UL;
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4607182418800017408UL, "ulong-double-implicit-unchecked-variable-2");
        }
        {
            ulong input = 9007199254740991UL;
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653695UL, "ulong-double-implicit-unchecked-variable-3");
        }
        {
            ulong input = 9007199254740992UL;
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653696UL, "ulong-double-implicit-unchecked-variable-4");
        }
        {
            ulong input = 9007199254740993UL;
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4845873199050653696UL, "ulong-double-implicit-unchecked-variable-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
