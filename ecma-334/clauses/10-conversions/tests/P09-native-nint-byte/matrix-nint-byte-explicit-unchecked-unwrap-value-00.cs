/*
Rules: P09-native-nint-byte; P09-native-nullable-unwrap
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
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "nint-byte-explicit-unchecked-unwrap-0");
        }
        {
            nint? input = (nint)(9223372036854775807L);
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "nint-byte-explicit-unchecked-unwrap-1");
        }
        {
            nint? input = (nint)(0L);
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "nint-byte-explicit-unchecked-unwrap-2");
        }
        {
            nint? input = (nint)(1L);
            byte result = unchecked((byte)input);
            Check(result==(byte)(1), "nint-byte-explicit-unchecked-unwrap-3");
        }
        {
            nint? input = (nint)(-1L);
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "nint-byte-explicit-unchecked-unwrap-4");
        }
        {
            nint? input = (nint)(254L);
            byte result = unchecked((byte)input);
            Check(result==(byte)(254), "nint-byte-explicit-unchecked-unwrap-5");
        }
        {
            nint? input = (nint)(255L);
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "nint-byte-explicit-unchecked-unwrap-6");
        }
        {
            nint? input = (nint)(256L);
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "nint-byte-explicit-unchecked-unwrap-7");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
