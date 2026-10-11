/*
Rules: P09-native-nint-float; P09-native-nullable-unwrap
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 11
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
            nint? input = (nint)(long.MinValue);
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3741319168U, "nint-float-explicit-unchecked-unwrap-0");
        }
        {
            nint? input = (nint)(9223372036854775807L);
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1593835520U, "nint-float-explicit-unchecked-unwrap-1");
        }
        {
            nint? input = (nint)(0L);
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==0U, "nint-float-explicit-unchecked-unwrap-2");
        }
        {
            nint? input = (nint)(1L);
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1065353216U, "nint-float-explicit-unchecked-unwrap-3");
        }
        {
            nint? input = (nint)(-1L);
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3212836864U, "nint-float-explicit-unchecked-unwrap-4");
        }
        {
            nint? input = (nint)(16777215L);
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679807U, "nint-float-explicit-unchecked-unwrap-5");
        }
        {
            nint? input = (nint)(16777216L);
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "nint-float-explicit-unchecked-unwrap-6");
        }
        {
            nint? input = (nint)(16777217L);
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==1266679808U, "nint-float-explicit-unchecked-unwrap-7");
        }
        {
            nint? input = (nint)(-16777217L);
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163456U, "nint-float-explicit-unchecked-unwrap-8");
        }
        {
            nint? input = (nint)(-16777216L);
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163456U, "nint-float-explicit-unchecked-unwrap-9");
        }
        {
            nint? input = (nint)(-16777215L);
            float result = unchecked((float)input);
            Check(unchecked((uint)BitConverter.SingleToInt32Bits(result))==3414163455U, "nint-float-explicit-unchecked-unwrap-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
