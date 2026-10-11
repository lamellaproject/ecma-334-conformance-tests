/*
Rules: P09-native-nint-float
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 9
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
            const nint input = (nint)(0L);
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==0U, "nint-float-explicit-checked-True-2");
        }
        {
            const nint input = (nint)(1L);
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1065353216U, "nint-float-explicit-checked-True-3");
        }
        {
            const nint input = (nint)(-1L);
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3212836864U, "nint-float-explicit-checked-True-4");
        }
        {
            const nint input = (nint)(16777215L);
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679807U, "nint-float-explicit-checked-True-5");
        }
        {
            const nint input = (nint)(16777216L);
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "nint-float-explicit-checked-True-6");
        }
        {
            const nint input = (nint)(16777217L);
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "nint-float-explicit-checked-True-7");
        }
        {
            const nint input = (nint)(-16777217L);
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163456U, "nint-float-explicit-checked-True-8");
        }
        {
            const nint input = (nint)(-16777216L);
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163456U, "nint-float-explicit-checked-True-9");
        }
        {
            const nint input = (nint)(-16777215L);
            float result = checked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163455U, "nint-float-explicit-checked-True-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
