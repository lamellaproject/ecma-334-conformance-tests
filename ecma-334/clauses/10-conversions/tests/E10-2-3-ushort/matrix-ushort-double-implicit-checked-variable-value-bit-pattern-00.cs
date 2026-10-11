/*
Rules: E10-2-3-ushort
Authority: ECMA-334 7th ed 10.2.3
Version: 7.3
Expected: run
Stdout: OK 3
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
            ushort input = (ushort)(0);
            double result = checked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==0UL, "ushort-double-implicit-checked-variable-0");
        }
        {
            ushort input = (ushort)(65535);
            double result = checked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4679239875398991872UL, "ushort-double-implicit-checked-variable-1");
        }
        {
            ushort input = (ushort)(1);
            double result = checked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4607182418800017408UL, "ushort-double-implicit-checked-variable-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
