/*
Rules: P09-native-nuint-long
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
            long result = checked((long)input);
            Check(result==0L, "nuint-long-explicit-checked-False-0");
        }
        {
            nuint input = (nuint)(1UL);
            long result = checked((long)input);
            Check(result==1L, "nuint-long-explicit-checked-False-2");
        }
        {
            nuint input = (nuint)(9223372036854775806UL);
            long result = checked((long)input);
            Check(result==9223372036854775806L, "nuint-long-explicit-checked-False-3");
        }
        {
            nuint input = (nuint)(9223372036854775807UL);
            long result = checked((long)input);
            Check(result==9223372036854775807L, "nuint-long-explicit-checked-False-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
