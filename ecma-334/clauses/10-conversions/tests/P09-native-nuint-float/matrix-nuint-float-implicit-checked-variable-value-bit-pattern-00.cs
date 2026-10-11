/*
Rules: P09-native-nuint-float
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 6
Generated: clauses/10-conversions/generators/native-matrices.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        {
            nuint input = (nuint)(0UL);
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==0U, "nuint-float-implicit-checked-False-0");
        }
        {
            nuint input = (nuint)(18446744073709551615UL);
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1602224128U, "nuint-float-implicit-checked-False-1");
        }
        {
            nuint input = (nuint)(1UL);
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1065353216U, "nuint-float-implicit-checked-False-2");
        }
        {
            nuint input = (nuint)(16777215UL);
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679807U, "nuint-float-implicit-checked-False-3");
        }
        {
            nuint input = (nuint)(16777216UL);
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "nuint-float-implicit-checked-False-4");
        }
        {
            nuint input = (nuint)(16777217UL);
            float result = checked(input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "nuint-float-implicit-checked-False-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
