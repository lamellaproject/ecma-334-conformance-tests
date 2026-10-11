/*
Rules: P09-native-char-nint; P09-native-nullable-lift
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
            char? input = (char)(0);
            nint? result = unchecked((nint?)input);
            Check(result.HasValue && (long)result.Value==0L, "char-nint-explicit-unchecked-lift-0");
        }
        {
            char? input = (char)(65535);
            nint? result = unchecked((nint?)input);
            Check(result.HasValue && (long)result.Value==65535L, "char-nint-explicit-unchecked-lift-1");
        }
        {
            char? input = (char)(1);
            nint? result = unchecked((nint?)input);
            Check(result.HasValue && (long)result.Value==1L, "char-nint-explicit-unchecked-lift-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
