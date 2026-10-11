/*
Rules: P09-native-nint-short; P09-native-nullable-unwrap
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
            short result = unchecked((short)input);
            Check(result==(short)(0), "nint-short-explicit-unchecked-unwrap-0");
        }
        {
            nint? input = (nint)(9223372036854775807L);
            short result = unchecked((short)input);
            Check(result==(short)(-1), "nint-short-explicit-unchecked-unwrap-1");
        }
        {
            nint? input = (nint)(0L);
            short result = unchecked((short)input);
            Check(result==(short)(0), "nint-short-explicit-unchecked-unwrap-2");
        }
        {
            nint? input = (nint)(1L);
            short result = unchecked((short)input);
            Check(result==(short)(1), "nint-short-explicit-unchecked-unwrap-3");
        }
        {
            nint? input = (nint)(-1L);
            short result = unchecked((short)input);
            Check(result==(short)(-1), "nint-short-explicit-unchecked-unwrap-4");
        }
        {
            nint? input = (nint)(-32769L);
            short result = unchecked((short)input);
            Check(result==(short)(32767), "nint-short-explicit-unchecked-unwrap-5");
        }
        {
            nint? input = (nint)(-32768L);
            short result = unchecked((short)input);
            Check(result==(short)(-32768), "nint-short-explicit-unchecked-unwrap-6");
        }
        {
            nint? input = (nint)(-32767L);
            short result = unchecked((short)input);
            Check(result==(short)(-32767), "nint-short-explicit-unchecked-unwrap-7");
        }
        {
            nint? input = (nint)(32766L);
            short result = unchecked((short)input);
            Check(result==(short)(32766), "nint-short-explicit-unchecked-unwrap-8");
        }
        {
            nint? input = (nint)(32767L);
            short result = unchecked((short)input);
            Check(result==(short)(32767), "nint-short-explicit-unchecked-unwrap-9");
        }
        {
            nint? input = (nint)(32768L);
            short result = unchecked((short)input);
            Check(result==(short)(-32768), "nint-short-explicit-unchecked-unwrap-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
