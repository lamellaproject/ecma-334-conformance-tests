/*
Rules: P09-native-uint-nint
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 3
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
            uint input = 0U;
            nint result = checked((nint)input);
            Check((long)result==0L, "uint-nint-explicit-checked-False-0");
        }
        {
            uint input = 4294967295U;
            nint result = checked((nint)input);
            Check((long)result==4294967295L, "uint-nint-explicit-checked-False-1");
        }
        {
            uint input = 1U;
            nint result = checked((nint)input);
            Check((long)result==1L, "uint-nint-explicit-checked-False-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
