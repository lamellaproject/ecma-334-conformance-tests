/*
Rules: P09-native-char-nuint
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
            const char input = (char)(0);
            nuint result = checked((nuint)input);
            Check((ulong)result==0UL, "char-nuint-explicit-checked-True-0");
        }
        {
            const char input = (char)(65535);
            nuint result = checked((nuint)input);
            Check((ulong)result==65535UL, "char-nuint-explicit-checked-True-1");
        }
        {
            const char input = (char)(1);
            nuint result = checked((nuint)input);
            Check((ulong)result==1UL, "char-nuint-explicit-checked-True-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
