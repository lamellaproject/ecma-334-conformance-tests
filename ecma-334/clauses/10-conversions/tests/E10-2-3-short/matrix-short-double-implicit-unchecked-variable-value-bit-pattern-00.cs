/*
Rules: E10-2-3-short
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
            short input = (short)(-32768);
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==13898108450065350656UL, "short-double-implicit-unchecked-variable-0");
        }
        {
            short input = (short)(32767);
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4674736138332667904UL, "short-double-implicit-unchecked-variable-1");
        }
        {
            short input = (short)(0);
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==0UL, "short-double-implicit-unchecked-variable-2");
        }
        {
            short input = (short)(1);
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4607182418800017408UL, "short-double-implicit-unchecked-variable-3");
        }
        {
            short input = (short)(-1);
            double result = unchecked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==13830554455654793216UL, "short-double-implicit-unchecked-variable-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
