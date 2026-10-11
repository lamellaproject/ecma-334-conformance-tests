/*
Rules: P09-native-nint-short
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
            short result = checked((short)input);
            Check(result==(short)(0), "nint-short-explicit-checked-True-2");
        }
        {
            const nint input = (nint)(1L);
            short result = checked((short)input);
            Check(result==(short)(1), "nint-short-explicit-checked-True-3");
        }
        {
            const nint input = (nint)(-1L);
            short result = checked((short)input);
            Check(result==(short)(-1), "nint-short-explicit-checked-True-4");
        }
        {
            const nint input = (nint)(-32768L);
            short result = checked((short)input);
            Check(result==(short)(-32768), "nint-short-explicit-checked-True-6");
        }
        {
            const nint input = (nint)(-32767L);
            short result = checked((short)input);
            Check(result==(short)(-32767), "nint-short-explicit-checked-True-7");
        }
        {
            const nint input = (nint)(32766L);
            short result = checked((short)input);
            Check(result==(short)(32766), "nint-short-explicit-checked-True-8");
        }
        {
            const nint input = (nint)(32767L);
            short result = checked((short)input);
            Check(result==(short)(32767), "nint-short-explicit-checked-True-9");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
