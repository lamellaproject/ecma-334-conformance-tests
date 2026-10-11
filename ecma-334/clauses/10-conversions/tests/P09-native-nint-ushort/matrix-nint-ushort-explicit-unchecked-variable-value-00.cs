/*
Rules: P09-native-nint-ushort
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
            nint input = (nint)(long.MinValue);
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(0), "nint-ushort-explicit-unchecked-False-0");
        }
        {
            nint input = (nint)(9223372036854775807L);
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(65535), "nint-ushort-explicit-unchecked-False-1");
        }
        {
            nint input = (nint)(0L);
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(0), "nint-ushort-explicit-unchecked-False-2");
        }
        {
            nint input = (nint)(1L);
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(1), "nint-ushort-explicit-unchecked-False-3");
        }
        {
            nint input = (nint)(-1L);
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(65535), "nint-ushort-explicit-unchecked-False-4");
        }
        {
            nint input = (nint)(65534L);
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(65534), "nint-ushort-explicit-unchecked-False-5");
        }
        {
            nint input = (nint)(65535L);
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(65535), "nint-ushort-explicit-unchecked-False-6");
        }
        {
            nint input = (nint)(65536L);
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(0), "nint-ushort-explicit-unchecked-False-7");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
