/*
Rules: P09-native-ushort-nint
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
            nint result = checked(input);
            Check((long)result==0L, "ushort-nint-implicit-checked-False-0");
        }
        {
            ushort input = (ushort)(65535);
            nint result = checked(input);
            Check((long)result==65535L, "ushort-nint-implicit-checked-False-1");
        }
        {
            ushort input = (ushort)(1);
            nint result = checked(input);
            Check((long)result==1L, "ushort-nint-implicit-checked-False-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
