/*
Rules: P09-native-nuint-ushort; P09-native-nullable-unwrap
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
            nuint? input = (nuint)(0UL);
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(0), "nuint-ushort-explicit-unchecked-unwrap-0");
        }
        {
            nuint? input = (nuint)(18446744073709551615UL);
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(65535), "nuint-ushort-explicit-unchecked-unwrap-1");
        }
        {
            nuint? input = (nuint)(1UL);
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(1), "nuint-ushort-explicit-unchecked-unwrap-2");
        }
        {
            nuint? input = (nuint)(65534UL);
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(65534), "nuint-ushort-explicit-unchecked-unwrap-3");
        }
        {
            nuint? input = (nuint)(65535UL);
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(65535), "nuint-ushort-explicit-unchecked-unwrap-4");
        }
        {
            nuint? input = (nuint)(65536UL);
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(0), "nuint-ushort-explicit-unchecked-unwrap-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
