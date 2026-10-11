/*
Rules: P09-native-nint-uint
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
            const nint input = (nint)(0L);
            uint result = unchecked((uint)input);
            Check(result==0U, "nint-uint-explicit-unchecked-True-2");
        }
        {
            const nint input = (nint)(1L);
            uint result = unchecked((uint)input);
            Check(result==1U, "nint-uint-explicit-unchecked-True-3");
        }
        {
            const nint input = (nint)(-1L);
            uint result = unchecked((uint)input);
            Check(result==4294967295U, "nint-uint-explicit-unchecked-True-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
