/*
Rules: P09-native-nint-short
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
            nint input = (nint)(long.MinValue);
            short result = unchecked((short)input);
            Check(result==(short)(0), "nint-short-explicit-unchecked-False-0");
        }
        {
            nint input = (nint)(9223372036854775807L);
            short result = unchecked((short)input);
            Check(result==(short)(-1), "nint-short-explicit-unchecked-False-1");
        }
        {
            nint input = (nint)(0L);
            short result = unchecked((short)input);
            Check(result==(short)(0), "nint-short-explicit-unchecked-False-2");
        }
        {
            nint input = (nint)(1L);
            short result = unchecked((short)input);
            Check(result==(short)(1), "nint-short-explicit-unchecked-False-3");
        }
        {
            nint input = (nint)(-1L);
            short result = unchecked((short)input);
            Check(result==(short)(-1), "nint-short-explicit-unchecked-False-4");
        }
        {
            nint input = (nint)(-32769L);
            short result = unchecked((short)input);
            Check(result==(short)(32767), "nint-short-explicit-unchecked-False-5");
        }
        {
            nint input = (nint)(-32768L);
            short result = unchecked((short)input);
            Check(result==(short)(-32768), "nint-short-explicit-unchecked-False-6");
        }
        {
            nint input = (nint)(-32767L);
            short result = unchecked((short)input);
            Check(result==(short)(-32767), "nint-short-explicit-unchecked-False-7");
        }
        {
            nint input = (nint)(32766L);
            short result = unchecked((short)input);
            Check(result==(short)(32766), "nint-short-explicit-unchecked-False-8");
        }
        {
            nint input = (nint)(32767L);
            short result = unchecked((short)input);
            Check(result==(short)(32767), "nint-short-explicit-unchecked-False-9");
        }
        {
            nint input = (nint)(32768L);
            short result = unchecked((short)input);
            Check(result==(short)(-32768), "nint-short-explicit-unchecked-False-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
