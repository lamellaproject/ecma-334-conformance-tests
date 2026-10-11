/*
Rules: P09-native-sbyte-nint
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
            const sbyte input = (sbyte)(-128);
            nint result = checked((nint)input);
            Check((long)result==-128L, "sbyte-nint-explicit-checked-True-0");
        }
        {
            const sbyte input = (sbyte)(127);
            nint result = checked((nint)input);
            Check((long)result==127L, "sbyte-nint-explicit-checked-True-1");
        }
        {
            const sbyte input = (sbyte)(0);
            nint result = checked((nint)input);
            Check((long)result==0L, "sbyte-nint-explicit-checked-True-2");
        }
        {
            const sbyte input = (sbyte)(1);
            nint result = checked((nint)input);
            Check((long)result==1L, "sbyte-nint-explicit-checked-True-3");
        }
        {
            const sbyte input = (sbyte)(-1);
            nint result = checked((nint)input);
            Check((long)result==-1L, "sbyte-nint-explicit-checked-True-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
