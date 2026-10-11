/*
Rules: P09-native-short-nint; P09-native-nullable-unwrap
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 5
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
            short? input = (short)(-32768);
            nint result = checked((nint)input);
            Check((long)result==-32768L, "short-nint-explicit-checked-unwrap-0");
        }
        {
            short? input = (short)(32767);
            nint result = checked((nint)input);
            Check((long)result==32767L, "short-nint-explicit-checked-unwrap-1");
        }
        {
            short? input = (short)(0);
            nint result = checked((nint)input);
            Check((long)result==0L, "short-nint-explicit-checked-unwrap-2");
        }
        {
            short? input = (short)(1);
            nint result = checked((nint)input);
            Check((long)result==1L, "short-nint-explicit-checked-unwrap-3");
        }
        {
            short? input = (short)(-1);
            nint result = checked((nint)input);
            Check((long)result==-1L, "short-nint-explicit-checked-unwrap-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
