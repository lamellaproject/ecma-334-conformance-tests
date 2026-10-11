/*
Rules: P09-native-float-nint
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 7
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
            float input = 0.0f;
            nint result = unchecked((nint)input);
            Check((long)result==0L, "float-nint-explicit-unchecked-False-2");
        }
        {
            float input = -0.0f;
            nint result = unchecked((nint)input);
            Check((long)result==0L, "float-nint-explicit-unchecked-False-3");
        }
        {
            float input = 1.0f;
            nint result = unchecked((nint)input);
            Check((long)result==1L, "float-nint-explicit-unchecked-False-4");
        }
        {
            float input = -1.0f;
            nint result = unchecked((nint)input);
            Check((long)result==-1L, "float-nint-explicit-unchecked-False-5");
        }
        {
            float input = 0.75f;
            nint result = unchecked((nint)input);
            Check((long)result==0L, "float-nint-explicit-unchecked-False-6");
        }
        {
            float input = -0.75f;
            nint result = unchecked((nint)input);
            Check((long)result==0L, "float-nint-explicit-unchecked-False-7");
        }
        {
            float input = -9.22337204e+18f;
            nint result = unchecked((nint)input);
            Check((long)result==long.MinValue, "float-nint-explicit-unchecked-False-11");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
