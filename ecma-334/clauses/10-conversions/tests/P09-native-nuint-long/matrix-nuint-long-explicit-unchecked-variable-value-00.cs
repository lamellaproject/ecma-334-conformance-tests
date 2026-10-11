/*
Rules: P09-native-nuint-long
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 6
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
            nuint input = (nuint)(0UL);
            long result = unchecked((long)input);
            Check(result==0L, "nuint-long-explicit-unchecked-False-0");
        }
        {
            nuint input = (nuint)(18446744073709551615UL);
            long result = unchecked((long)input);
            Check(result==-1L, "nuint-long-explicit-unchecked-False-1");
        }
        {
            nuint input = (nuint)(1UL);
            long result = unchecked((long)input);
            Check(result==1L, "nuint-long-explicit-unchecked-False-2");
        }
        {
            nuint input = (nuint)(9223372036854775806UL);
            long result = unchecked((long)input);
            Check(result==9223372036854775806L, "nuint-long-explicit-unchecked-False-3");
        }
        {
            nuint input = (nuint)(9223372036854775807UL);
            long result = unchecked((long)input);
            Check(result==9223372036854775807L, "nuint-long-explicit-unchecked-False-4");
        }
        {
            nuint input = (nuint)(9223372036854775808UL);
            long result = unchecked((long)input);
            Check(result==long.MinValue, "nuint-long-explicit-unchecked-False-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
