/*
Rules: E10-2-3-int
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
            int input = -2147483648;
            double result = checked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==13970166044103278592UL, "int-double-implicit-checked-variable-0");
        }
        {
            int input = 2147483647;
            double result = checked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4746794007244308480UL, "int-double-implicit-checked-variable-1");
        }
        {
            int input = 0;
            double result = checked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==0UL, "int-double-implicit-checked-variable-2");
        }
        {
            int input = 1;
            double result = checked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4607182418800017408UL, "int-double-implicit-checked-variable-3");
        }
        {
            int input = -1;
            double result = checked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==13830554455654793216UL, "int-double-implicit-checked-variable-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
