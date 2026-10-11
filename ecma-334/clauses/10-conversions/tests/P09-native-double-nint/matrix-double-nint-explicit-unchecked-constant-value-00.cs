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
            const double input = 0.0d;
            nint result = unchecked((nint)input);
            Check((long)result==0L, "double-nint-explicit-unchecked-True-2");
        }
        {
            const double input = -0.0d;
            nint result = unchecked((nint)input);
            Check((long)result==0L, "double-nint-explicit-unchecked-True-3");
        }
        {
            const double input = 1.0d;
            nint result = unchecked((nint)input);
            Check((long)result==1L, "double-nint-explicit-unchecked-True-4");
        }
        {
            const double input = -1.0d;
            nint result = unchecked((nint)input);
            Check((long)result==-1L, "double-nint-explicit-unchecked-True-5");
        }
        {
            const double input = 0.75d;
            nint result = unchecked((nint)input);
            Check((long)result==0L, "double-nint-explicit-unchecked-True-6");
        }
        {
            const double input = -0.75d;
            nint result = unchecked((nint)input);
            Check((long)result==0L, "double-nint-explicit-unchecked-True-7");
        }
        {
            const double input = -9.2233720368547758e+18d;
            nint result = unchecked((nint)input);
            Check((long)result==long.MinValue, "double-nint-explicit-unchecked-True-11");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
