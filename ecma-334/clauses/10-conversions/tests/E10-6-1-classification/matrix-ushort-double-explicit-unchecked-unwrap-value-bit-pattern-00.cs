/*
Rules: E10-6-1-classification; E10-6-1-unwrap
Authority: ECMA-334 7th ed 10.6.1
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
            ushort? input = (ushort)(0);
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==0UL, "nullable-ushort-double-explicit-unchecked-unwrap-0");
        }
        {
            ushort? input = (ushort)(65535);
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4679239875398991872UL, "nullable-ushort-double-explicit-unchecked-unwrap-1");
        }
        {
            ushort? input = (ushort)(1);
            double result = unchecked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4607182418800017408UL, "nullable-ushort-double-explicit-unchecked-unwrap-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
