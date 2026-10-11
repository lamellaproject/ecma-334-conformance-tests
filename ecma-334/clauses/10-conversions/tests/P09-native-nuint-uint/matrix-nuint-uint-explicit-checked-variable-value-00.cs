/*
Rules: P09-native-nuint-uint
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
            nuint input = (nuint)(0UL);
            uint result = checked((uint)input);
            Check(result==0U, "nuint-uint-explicit-checked-False-0");
        }
        {
            nuint input = (nuint)(1UL);
            uint result = checked((uint)input);
            Check(result==1U, "nuint-uint-explicit-checked-False-2");
        }
        {
            nuint input = (nuint)(4294967294UL);
            uint result = checked((uint)input);
            Check(result==4294967294U, "nuint-uint-explicit-checked-False-3");
        }
        {
            nuint input = (nuint)(4294967295UL);
            uint result = checked((uint)input);
            Check(result==4294967295U, "nuint-uint-explicit-checked-False-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
