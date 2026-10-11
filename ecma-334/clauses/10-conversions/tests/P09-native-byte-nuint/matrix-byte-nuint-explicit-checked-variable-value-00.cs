/*
Rules: P09-native-byte-nuint
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
            byte input = (byte)(0);
            nuint result = checked((nuint)input);
            Check((ulong)result==0UL, "byte-nuint-explicit-checked-False-0");
        }
        {
            byte input = (byte)(255);
            nuint result = checked((nuint)input);
            Check((ulong)result==255UL, "byte-nuint-explicit-checked-False-1");
        }
        {
            byte input = (byte)(1);
            nuint result = checked((nuint)input);
            Check((ulong)result==1UL, "byte-nuint-explicit-checked-False-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
