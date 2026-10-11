/*
Rules: P09-native-ushort-nuint
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
            ushort input = (ushort)(0);
            nuint result = checked((nuint)input);
            Check((ulong)result==0UL, "ushort-nuint-explicit-checked-False-0");
        }
        {
            ushort input = (ushort)(65535);
            nuint result = checked((nuint)input);
            Check((ulong)result==65535UL, "ushort-nuint-explicit-checked-False-1");
        }
        {
            ushort input = (ushort)(1);
            nuint result = checked((nuint)input);
            Check((ulong)result==1UL, "ushort-nuint-explicit-checked-False-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
