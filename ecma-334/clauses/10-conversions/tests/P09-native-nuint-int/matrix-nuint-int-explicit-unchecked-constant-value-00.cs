/*
Rules: P09-native-nuint-int
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
            int result = unchecked((int)input);
            Check(result==0, "nuint-int-explicit-unchecked-True-0");
        }
        {
            const nuint input = (nuint)(1UL);
            int result = unchecked((int)input);
            Check(result==1, "nuint-int-explicit-unchecked-True-2");
        }
        {
            const nuint input = (nuint)(2147483646UL);
            int result = unchecked((int)input);
            Check(result==2147483646, "nuint-int-explicit-unchecked-True-3");
        }
        {
            const nuint input = (nuint)(2147483647UL);
            int result = unchecked((int)input);
            Check(result==2147483647, "nuint-int-explicit-unchecked-True-4");
        }
        {
            const nuint input = (nuint)(2147483648UL);
            int result = unchecked((int)input);
            Check(result==-2147483648, "nuint-int-explicit-unchecked-True-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
