/*
Rules: P09-native-nuint-int; P09-native-nullable-unwrap
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
            int result = checked((int)input);
            Check(result==0, "nuint-int-explicit-checked-unwrap-0");
        }
        {
            nuint? input = (nuint)(1UL);
            int result = checked((int)input);
            Check(result==1, "nuint-int-explicit-checked-unwrap-2");
        }
        {
            nuint? input = (nuint)(2147483646UL);
            int result = checked((int)input);
            Check(result==2147483646, "nuint-int-explicit-checked-unwrap-3");
        }
        {
            nuint? input = (nuint)(2147483647UL);
            int result = checked((int)input);
            Check(result==2147483647, "nuint-int-explicit-checked-unwrap-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
