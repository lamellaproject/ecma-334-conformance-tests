/*
Rules: P09-native-uint-nuint
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 3
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
            const uint input = 0U;
            nuint result = checked(input);
            Check((ulong)result==0UL, "uint-nuint-implicit-checked-True-0");
        }
        {
            const uint input = 4294967295U;
            nuint result = checked(input);
            Check((ulong)result==4294967295UL, "uint-nuint-implicit-checked-True-1");
        }
        {
            const uint input = 1U;
            nuint result = checked(input);
            Check((ulong)result==1UL, "uint-nuint-implicit-checked-True-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
