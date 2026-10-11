/*
Rules: P09-native-nuint-decimal; P09-native-nullable-unwrap
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
            nuint? input = (nuint)(0UL);
            decimal result = checked((decimal)input);
            Check(result==0m, "nuint-decimal-explicit-checked-unwrap-0");
        }
        {
            nuint? input = (nuint)(18446744073709551615UL);
            decimal result = checked((decimal)input);
            Check(result==18446744073709551615m, "nuint-decimal-explicit-checked-unwrap-1");
        }
        {
            nuint? input = (nuint)(1UL);
            decimal result = checked((decimal)input);
            Check(result==1m, "nuint-decimal-explicit-checked-unwrap-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
