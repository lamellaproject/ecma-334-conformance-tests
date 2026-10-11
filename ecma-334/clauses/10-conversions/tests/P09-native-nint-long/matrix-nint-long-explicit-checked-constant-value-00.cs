/*
Rules: P09-native-nint-long
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
            long result = checked((long)input);
            Check(result==0L, "nint-long-explicit-checked-True-2");
        }
        {
            const nint input = (nint)(1L);
            long result = checked((long)input);
            Check(result==1L, "nint-long-explicit-checked-True-3");
        }
        {
            const nint input = (nint)(-1L);
            long result = checked((long)input);
            Check(result==-1L, "nint-long-explicit-checked-True-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
