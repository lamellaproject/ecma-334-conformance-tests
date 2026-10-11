/*
Rules: P09-native-double-nint
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
            double input = 0.0d;
            nint result = checked((nint)input);
            Check((long)result==0L, "double-nint-explicit-checked-False-2");
        }
        {
            double input = -0.0d;
            nint result = checked((nint)input);
            Check((long)result==0L, "double-nint-explicit-checked-False-3");
        }
        {
            double input = 1.0d;
            nint result = checked((nint)input);
            Check((long)result==1L, "double-nint-explicit-checked-False-4");
        }
        {
            double input = -1.0d;
            nint result = checked((nint)input);
            Check((long)result==-1L, "double-nint-explicit-checked-False-5");
        }
        {
            double input = 0.75d;
            nint result = checked((nint)input);
            Check((long)result==0L, "double-nint-explicit-checked-False-6");
        }
        {
            double input = -0.75d;
            nint result = checked((nint)input);
            Check((long)result==0L, "double-nint-explicit-checked-False-7");
        }
        {
            double input = -9.2233720368547758e+18d;
            nint result = checked((nint)input);
            Check((long)result==long.MinValue, "double-nint-explicit-checked-False-11");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
