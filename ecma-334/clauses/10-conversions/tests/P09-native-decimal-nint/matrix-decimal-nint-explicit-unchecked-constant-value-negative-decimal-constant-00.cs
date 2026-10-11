/*
Rules: P09-native-decimal-nint
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
            const decimal input = -1m;
            nint result = unchecked((nint)input);
            Check((long)result==-1L, "decimal-nint-explicit-unchecked-True-4");
        }
        {
            const decimal input = -0.1m;
            nint result = unchecked((nint)input);
            Check((long)result==0L, "decimal-nint-explicit-unchecked-True-6");
        }
        {
            const decimal input = -1E-28m;
            nint result = unchecked((nint)input);
            Check((long)result==0L, "decimal-nint-explicit-unchecked-True-8");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
