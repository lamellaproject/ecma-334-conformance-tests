/*
Rules: E10-2-3-byte
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
            byte input = (byte)(0);
            double result = checked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==0UL, "byte-double-implicit-checked-variable-0");
        }
        {
            byte input = (byte)(255);
            double result = checked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4643176031446892544UL, "byte-double-implicit-checked-variable-1");
        }
        {
            byte input = (byte)(1);
            double result = checked(input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==4607182418800017408UL, "byte-double-implicit-checked-variable-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
