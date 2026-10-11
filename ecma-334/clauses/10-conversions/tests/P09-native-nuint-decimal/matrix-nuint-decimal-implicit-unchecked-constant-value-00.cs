/*
Rules: P09-native-nuint-decimal
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 2
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
            decimal result = unchecked(input);
            Check(result==0m, "nuint-decimal-implicit-unchecked-True-0");
        }
        {
            const nuint input = (nuint)(1UL);
            decimal result = unchecked(input);
            Check(result==1m, "nuint-decimal-implicit-unchecked-True-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
