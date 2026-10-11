/*
Rules: P09-native-nint-ushort
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 6
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
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(0), "nint-ushort-explicit-unchecked-True-2");
        }
        {
            const nint input = (nint)(1L);
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(1), "nint-ushort-explicit-unchecked-True-3");
        }
        {
            const nint input = (nint)(-1L);
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(65535), "nint-ushort-explicit-unchecked-True-4");
        }
        {
            const nint input = (nint)(65534L);
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(65534), "nint-ushort-explicit-unchecked-True-5");
        }
        {
            const nint input = (nint)(65535L);
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(65535), "nint-ushort-explicit-unchecked-True-6");
        }
        {
            const nint input = (nint)(65536L);
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(0), "nint-ushort-explicit-unchecked-True-7");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
