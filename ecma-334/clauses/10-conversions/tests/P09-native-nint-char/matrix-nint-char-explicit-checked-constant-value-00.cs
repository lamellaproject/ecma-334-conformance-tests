/*
Rules: P09-native-nint-char
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 4
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
            char result = checked((char)input);
            Check(result==(char)(0), "nint-char-explicit-checked-True-2");
        }
        {
            const nint input = (nint)(1L);
            char result = checked((char)input);
            Check(result==(char)(1), "nint-char-explicit-checked-True-3");
        }
        {
            const nint input = (nint)(65534L);
            char result = checked((char)input);
            Check(result==(char)(65534), "nint-char-explicit-checked-True-5");
        }
        {
            const nint input = (nint)(65535L);
            char result = checked((char)input);
            Check(result==(char)(65535), "nint-char-explicit-checked-True-6");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
