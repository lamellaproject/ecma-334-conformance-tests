/*
Rules: P09-native-nint-int; P09-native-nullable-unwrap
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
            nint? input = (nint)(0L);
            int result = checked((int)input);
            Check(result==0, "nint-int-explicit-checked-unwrap-2");
        }
        {
            nint? input = (nint)(1L);
            int result = checked((int)input);
            Check(result==1, "nint-int-explicit-checked-unwrap-3");
        }
        {
            nint? input = (nint)(-1L);
            int result = checked((int)input);
            Check(result==-1, "nint-int-explicit-checked-unwrap-4");
        }
        {
            nint? input = (nint)(-2147483648L);
            int result = checked((int)input);
            Check(result==-2147483648, "nint-int-explicit-checked-unwrap-6");
        }
        {
            nint? input = (nint)(-2147483647L);
            int result = checked((int)input);
            Check(result==-2147483647, "nint-int-explicit-checked-unwrap-7");
        }
        {
            nint? input = (nint)(2147483646L);
            int result = checked((int)input);
            Check(result==2147483646, "nint-int-explicit-checked-unwrap-8");
        }
        {
            nint? input = (nint)(2147483647L);
            int result = checked((int)input);
            Check(result==2147483647, "nint-int-explicit-checked-unwrap-9");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
