/*
Rules: P09-native-nint-long; P09-native-nullable-lift
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 7
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
            long? result = checked(input);
            Check(result.HasValue && result.Value==long.MinValue, "nint-long-implicit-checked-lift-0");
        }
        {
            nint? input = (nint)(9223372036854775807L);
            long? result = checked(input);
            Check(result.HasValue && result.Value==9223372036854775807L, "nint-long-implicit-checked-lift-1");
        }
        {
            nint? input = (nint)(0L);
            long? result = checked(input);
            Check(result.HasValue && result.Value==0L, "nint-long-implicit-checked-lift-2");
        }
        {
            nint? input = (nint)(1L);
            long? result = checked(input);
            Check(result.HasValue && result.Value==1L, "nint-long-implicit-checked-lift-3");
        }
        {
            nint? input = (nint)(-1L);
            long? result = checked(input);
            Check(result.HasValue && result.Value==-1L, "nint-long-implicit-checked-lift-4");
        }
        {
            nint? input = (nint)(-9223372036854775807L);
            long? result = checked(input);
            Check(result.HasValue && result.Value==-9223372036854775807L, "nint-long-implicit-checked-lift-5");
        }
        {
            nint? input = (nint)(9223372036854775806L);
            long? result = checked(input);
            Check(result.HasValue && result.Value==9223372036854775806L, "nint-long-implicit-checked-lift-6");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
