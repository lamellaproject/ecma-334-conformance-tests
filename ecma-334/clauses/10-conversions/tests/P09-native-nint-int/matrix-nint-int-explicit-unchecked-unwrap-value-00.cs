/*
Rules: P09-native-nint-int; P09-native-nullable-unwrap
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 11
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
            nint? input = (nint)(long.MinValue);
            int result = unchecked((int)input);
            Check(result==0, "nint-int-explicit-unchecked-unwrap-0");
        }
        {
            nint? input = (nint)(9223372036854775807L);
            int result = unchecked((int)input);
            Check(result==-1, "nint-int-explicit-unchecked-unwrap-1");
        }
        {
            nint? input = (nint)(0L);
            int result = unchecked((int)input);
            Check(result==0, "nint-int-explicit-unchecked-unwrap-2");
        }
        {
            nint? input = (nint)(1L);
            int result = unchecked((int)input);
            Check(result==1, "nint-int-explicit-unchecked-unwrap-3");
        }
        {
            nint? input = (nint)(-1L);
            int result = unchecked((int)input);
            Check(result==-1, "nint-int-explicit-unchecked-unwrap-4");
        }
        {
            nint? input = (nint)(-2147483649L);
            int result = unchecked((int)input);
            Check(result==2147483647, "nint-int-explicit-unchecked-unwrap-5");
        }
        {
            nint? input = (nint)(-2147483648L);
            int result = unchecked((int)input);
            Check(result==-2147483648, "nint-int-explicit-unchecked-unwrap-6");
        }
        {
            nint? input = (nint)(-2147483647L);
            int result = unchecked((int)input);
            Check(result==-2147483647, "nint-int-explicit-unchecked-unwrap-7");
        }
        {
            nint? input = (nint)(2147483646L);
            int result = unchecked((int)input);
            Check(result==2147483646, "nint-int-explicit-unchecked-unwrap-8");
        }
        {
            nint? input = (nint)(2147483647L);
            int result = unchecked((int)input);
            Check(result==2147483647, "nint-int-explicit-unchecked-unwrap-9");
        }
        {
            nint? input = (nint)(2147483648L);
            int result = unchecked((int)input);
            Check(result==-2147483648, "nint-int-explicit-unchecked-unwrap-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
