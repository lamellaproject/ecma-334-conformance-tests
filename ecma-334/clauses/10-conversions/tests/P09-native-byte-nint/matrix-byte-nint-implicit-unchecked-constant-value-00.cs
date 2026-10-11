/*
Rules: P09-native-byte-nint
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
            const byte input = (byte)(0);
            nint result = unchecked(input);
            Check((long)result==0L, "byte-nint-implicit-unchecked-True-0");
        }
        {
            const byte input = (byte)(255);
            nint result = unchecked(input);
            Check((long)result==255L, "byte-nint-implicit-unchecked-True-1");
        }
        {
            const byte input = (byte)(1);
            nint result = unchecked(input);
            Check((long)result==1L, "byte-nint-implicit-unchecked-True-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
