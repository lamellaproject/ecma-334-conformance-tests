/*
Rules: P09-native-nint-char; P09-native-nullable-unwrap
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 8
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
            nint? input = (nint)(long.MinValue);
            char result = unchecked((char)input);
            Check(result==(char)(0), "nint-char-explicit-unchecked-unwrap-0");
        }
        {
            nint? input = (nint)(9223372036854775807L);
            char result = unchecked((char)input);
            Check(result==(char)(65535), "nint-char-explicit-unchecked-unwrap-1");
        }
        {
            nint? input = (nint)(0L);
            char result = unchecked((char)input);
            Check(result==(char)(0), "nint-char-explicit-unchecked-unwrap-2");
        }
        {
            nint? input = (nint)(1L);
            char result = unchecked((char)input);
            Check(result==(char)(1), "nint-char-explicit-unchecked-unwrap-3");
        }
        {
            nint? input = (nint)(-1L);
            char result = unchecked((char)input);
            Check(result==(char)(65535), "nint-char-explicit-unchecked-unwrap-4");
        }
        {
            nint? input = (nint)(65534L);
            char result = unchecked((char)input);
            Check(result==(char)(65534), "nint-char-explicit-unchecked-unwrap-5");
        }
        {
            nint? input = (nint)(65535L);
            char result = unchecked((char)input);
            Check(result==(char)(65535), "nint-char-explicit-unchecked-unwrap-6");
        }
        {
            nint? input = (nint)(65536L);
            char result = unchecked((char)input);
            Check(result==(char)(0), "nint-char-explicit-unchecked-unwrap-7");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
