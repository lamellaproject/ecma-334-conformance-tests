/*
Rules: P09-native-byte-nint; P09-native-nullable-lift
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
            byte? input = (byte)(0);
            nint? result = checked(input);
            Check(result.HasValue && (long)result.Value==0L, "byte-nint-implicit-checked-lift-0");
        }
        {
            byte? input = (byte)(255);
            nint? result = checked(input);
            Check(result.HasValue && (long)result.Value==255L, "byte-nint-implicit-checked-lift-1");
        }
        {
            byte? input = (byte)(1);
            nint? result = checked(input);
            Check(result.HasValue && (long)result.Value==1L, "byte-nint-implicit-checked-lift-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
