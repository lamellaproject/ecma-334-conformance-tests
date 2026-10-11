/*
Rules: P09-native-nuint-char
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 5
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
            char result = unchecked((char)input);
            Check(result==(char)(0), "nuint-char-explicit-unchecked-True-0");
        }
        {
            const nuint input = (nuint)(1UL);
            char result = unchecked((char)input);
            Check(result==(char)(1), "nuint-char-explicit-unchecked-True-2");
        }
        {
            const nuint input = (nuint)(65534UL);
            char result = unchecked((char)input);
            Check(result==(char)(65534), "nuint-char-explicit-unchecked-True-3");
        }
        {
            const nuint input = (nuint)(65535UL);
            char result = unchecked((char)input);
            Check(result==(char)(65535), "nuint-char-explicit-unchecked-True-4");
        }
        {
            const nuint input = (nuint)(65536UL);
            char result = unchecked((char)input);
            Check(result==(char)(0), "nuint-char-explicit-unchecked-True-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
