/*
Rules: P09-native-short-nint
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
            const short input = (short)(-32768);
            nint result = checked(input);
            Check((long)result==-32768L, "short-nint-implicit-checked-True-0");
        }
        {
            const short input = (short)(32767);
            nint result = checked(input);
            Check((long)result==32767L, "short-nint-implicit-checked-True-1");
        }
        {
            const short input = (short)(0);
            nint result = checked(input);
            Check((long)result==0L, "short-nint-implicit-checked-True-2");
        }
        {
            const short input = (short)(1);
            nint result = checked(input);
            Check((long)result==1L, "short-nint-implicit-checked-True-3");
        }
        {
            const short input = (short)(-1);
            nint result = checked(input);
            Check((long)result==-1L, "short-nint-implicit-checked-True-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
