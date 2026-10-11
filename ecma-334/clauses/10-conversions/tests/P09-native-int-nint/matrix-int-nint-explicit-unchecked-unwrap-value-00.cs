/*
Rules: P09-native-int-nint; P09-native-nullable-unwrap
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
            int? input = -2147483648;
            nint result = unchecked((nint)input);
            Check((long)result==-2147483648L, "int-nint-explicit-unchecked-unwrap-0");
        }
        {
            int? input = 2147483647;
            nint result = unchecked((nint)input);
            Check((long)result==2147483647L, "int-nint-explicit-unchecked-unwrap-1");
        }
        {
            int? input = 0;
            nint result = unchecked((nint)input);
            Check((long)result==0L, "int-nint-explicit-unchecked-unwrap-2");
        }
        {
            int? input = 1;
            nint result = unchecked((nint)input);
            Check((long)result==1L, "int-nint-explicit-unchecked-unwrap-3");
        }
        {
            int? input = -1;
            nint result = unchecked((nint)input);
            Check((long)result==-1L, "int-nint-explicit-unchecked-unwrap-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
