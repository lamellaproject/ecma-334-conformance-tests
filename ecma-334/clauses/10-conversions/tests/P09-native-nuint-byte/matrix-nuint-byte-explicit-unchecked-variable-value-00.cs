/*
Rules: P09-native-nuint-byte
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
            nuint input = (nuint)(0UL);
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "nuint-byte-explicit-unchecked-False-0");
        }
        {
            nuint input = (nuint)(18446744073709551615UL);
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "nuint-byte-explicit-unchecked-False-1");
        }
        {
            nuint input = (nuint)(1UL);
            byte result = unchecked((byte)input);
            Check(result==(byte)(1), "nuint-byte-explicit-unchecked-False-2");
        }
        {
            nuint input = (nuint)(254UL);
            byte result = unchecked((byte)input);
            Check(result==(byte)(254), "nuint-byte-explicit-unchecked-False-3");
        }
        {
            nuint input = (nuint)(255UL);
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "nuint-byte-explicit-unchecked-False-4");
        }
        {
            nuint input = (nuint)(256UL);
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "nuint-byte-explicit-unchecked-False-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
