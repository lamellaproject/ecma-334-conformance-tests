/*
Rules: P09-native-nint-uint
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
            uint result = unchecked((uint)input);
            Check(result==0U, "nint-uint-explicit-unchecked-False-0");
        }
        {
            nint input = (nint)(9223372036854775807L);
            uint result = unchecked((uint)input);
            Check(result==4294967295U, "nint-uint-explicit-unchecked-False-1");
        }
        {
            nint input = (nint)(0L);
            uint result = unchecked((uint)input);
            Check(result==0U, "nint-uint-explicit-unchecked-False-2");
        }
        {
            nint input = (nint)(1L);
            uint result = unchecked((uint)input);
            Check(result==1U, "nint-uint-explicit-unchecked-False-3");
        }
        {
            nint input = (nint)(-1L);
            uint result = unchecked((uint)input);
            Check(result==4294967295U, "nint-uint-explicit-unchecked-False-4");
        }
        {
            nint input = (nint)(4294967294L);
            uint result = unchecked((uint)input);
            Check(result==4294967294U, "nint-uint-explicit-unchecked-False-5");
        }
        {
            nint input = (nint)(4294967295L);
            uint result = unchecked((uint)input);
            Check(result==4294967295U, "nint-uint-explicit-unchecked-False-6");
        }
        {
            nint input = (nint)(4294967296L);
            uint result = unchecked((uint)input);
            Check(result==0U, "nint-uint-explicit-unchecked-False-7");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
