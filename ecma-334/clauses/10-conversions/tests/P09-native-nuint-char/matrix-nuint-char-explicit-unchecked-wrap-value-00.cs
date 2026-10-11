/*
Rules: P09-native-nuint-char; P09-native-nullable-wrap
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
            char? result = unchecked((char?)input);
            Check(result.HasValue && result.Value==(char)(0), "nuint-char-explicit-unchecked-wrap-0");
        }
        {
            nuint input = (nuint)(18446744073709551615UL);
            char? result = unchecked((char?)input);
            Check(result.HasValue && result.Value==(char)(65535), "nuint-char-explicit-unchecked-wrap-1");
        }
        {
            nuint input = (nuint)(1UL);
            char? result = unchecked((char?)input);
            Check(result.HasValue && result.Value==(char)(1), "nuint-char-explicit-unchecked-wrap-2");
        }
        {
            nuint input = (nuint)(65534UL);
            char? result = unchecked((char?)input);
            Check(result.HasValue && result.Value==(char)(65534), "nuint-char-explicit-unchecked-wrap-3");
        }
        {
            nuint input = (nuint)(65535UL);
            char? result = unchecked((char?)input);
            Check(result.HasValue && result.Value==(char)(65535), "nuint-char-explicit-unchecked-wrap-4");
        }
        {
            nuint input = (nuint)(65536UL);
            char? result = unchecked((char?)input);
            Check(result.HasValue && result.Value==(char)(0), "nuint-char-explicit-unchecked-wrap-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
