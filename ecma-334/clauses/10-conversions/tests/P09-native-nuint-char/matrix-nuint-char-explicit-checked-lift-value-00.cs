/*
Rules: P09-native-nuint-char; P09-native-nullable-lift
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
            nuint? input = (nuint)(0UL);
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(0), "nuint-char-explicit-checked-lift-0");
        }
        {
            nuint? input = (nuint)(1UL);
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(1), "nuint-char-explicit-checked-lift-2");
        }
        {
            nuint? input = (nuint)(65534UL);
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(65534), "nuint-char-explicit-checked-lift-3");
        }
        {
            nuint? input = (nuint)(65535UL);
            char? result = checked((char?)input);
            Check(result.HasValue && result.Value==(char)(65535), "nuint-char-explicit-checked-lift-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
