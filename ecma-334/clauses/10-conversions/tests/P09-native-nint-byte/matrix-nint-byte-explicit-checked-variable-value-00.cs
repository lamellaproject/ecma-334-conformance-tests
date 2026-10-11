/*
Rules: P09-native-nint-byte
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
            nint input = (nint)(0L);
            byte result = checked((byte)input);
            Check(result==(byte)(0), "nint-byte-explicit-checked-False-2");
        }
        {
            nint input = (nint)(1L);
            byte result = checked((byte)input);
            Check(result==(byte)(1), "nint-byte-explicit-checked-False-3");
        }
        {
            nint input = (nint)(254L);
            byte result = checked((byte)input);
            Check(result==(byte)(254), "nint-byte-explicit-checked-False-5");
        }
        {
            nint input = (nint)(255L);
            byte result = checked((byte)input);
            Check(result==(byte)(255), "nint-byte-explicit-checked-False-6");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
