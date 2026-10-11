/*
Rules: P09-native-nuint-short
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
            short result = unchecked((short)input);
            Check(result==(short)(0), "nuint-short-explicit-unchecked-True-0");
        }
        {
            const nuint input = (nuint)(1UL);
            short result = unchecked((short)input);
            Check(result==(short)(1), "nuint-short-explicit-unchecked-True-2");
        }
        {
            const nuint input = (nuint)(32766UL);
            short result = unchecked((short)input);
            Check(result==(short)(32766), "nuint-short-explicit-unchecked-True-3");
        }
        {
            const nuint input = (nuint)(32767UL);
            short result = unchecked((short)input);
            Check(result==(short)(32767), "nuint-short-explicit-unchecked-True-4");
        }
        {
            const nuint input = (nuint)(32768UL);
            short result = unchecked((short)input);
            Check(result==(short)(-32768), "nuint-short-explicit-unchecked-True-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
