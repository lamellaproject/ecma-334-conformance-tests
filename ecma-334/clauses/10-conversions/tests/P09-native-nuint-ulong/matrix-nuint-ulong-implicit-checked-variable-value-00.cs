/*
Rules: P09-native-nuint-ulong
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
            ulong result = checked(input);
            Check(result==0UL, "nuint-ulong-implicit-checked-False-0");
        }
        {
            nuint input = (nuint)(18446744073709551615UL);
            ulong result = checked(input);
            Check(result==18446744073709551615UL, "nuint-ulong-implicit-checked-False-1");
        }
        {
            nuint input = (nuint)(1UL);
            ulong result = checked(input);
            Check(result==1UL, "nuint-ulong-implicit-checked-False-2");
        }
        {
            nuint input = (nuint)(18446744073709551614UL);
            ulong result = checked(input);
            Check(result==18446744073709551614UL, "nuint-ulong-implicit-checked-False-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
