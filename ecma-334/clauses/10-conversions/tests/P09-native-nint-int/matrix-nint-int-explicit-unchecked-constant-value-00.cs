/*
Rules: P09-native-nint-int
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 7
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
            const nint input = (nint)(0L);
            int result = unchecked((int)input);
            Check(result==0, "nint-int-explicit-unchecked-True-2");
        }
        {
            const nint input = (nint)(1L);
            int result = unchecked((int)input);
            Check(result==1, "nint-int-explicit-unchecked-True-3");
        }
        {
            const nint input = (nint)(-1L);
            int result = unchecked((int)input);
            Check(result==-1, "nint-int-explicit-unchecked-True-4");
        }
        {
            const nint input = (nint)(-2147483648L);
            int result = unchecked((int)input);
            Check(result==-2147483648, "nint-int-explicit-unchecked-True-6");
        }
        {
            const nint input = (nint)(-2147483647L);
            int result = unchecked((int)input);
            Check(result==-2147483647, "nint-int-explicit-unchecked-True-7");
        }
        {
            const nint input = (nint)(2147483646L);
            int result = unchecked((int)input);
            Check(result==2147483646, "nint-int-explicit-unchecked-True-8");
        }
        {
            const nint input = (nint)(2147483647L);
            int result = unchecked((int)input);
            Check(result==2147483647, "nint-int-explicit-unchecked-True-9");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
