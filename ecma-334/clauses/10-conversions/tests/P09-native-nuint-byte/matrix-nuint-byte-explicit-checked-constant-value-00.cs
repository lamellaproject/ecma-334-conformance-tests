/*
Rules: P09-native-nuint-byte
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
            const nuint input = (nuint)(0UL);
            byte result = checked((byte)input);
            Check(result==(byte)(0), "nuint-byte-explicit-checked-True-0");
        }
        {
            const nuint input = (nuint)(1UL);
            byte result = checked((byte)input);
            Check(result==(byte)(1), "nuint-byte-explicit-checked-True-2");
        }
        {
            const nuint input = (nuint)(254UL);
            byte result = checked((byte)input);
            Check(result==(byte)(254), "nuint-byte-explicit-checked-True-3");
        }
        {
            const nuint input = (nuint)(255UL);
            byte result = checked((byte)input);
            Check(result==(byte)(255), "nuint-byte-explicit-checked-True-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
