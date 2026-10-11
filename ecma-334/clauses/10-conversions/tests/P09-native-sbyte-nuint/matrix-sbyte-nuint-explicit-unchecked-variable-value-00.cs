/*
Rules: P09-native-sbyte-nuint
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
            sbyte input = (sbyte)(-128);
            nuint result = unchecked((nuint)input);
            Check((ulong)result==18446744073709551488UL, "sbyte-nuint-explicit-unchecked-False-0");
        }
        {
            sbyte input = (sbyte)(127);
            nuint result = unchecked((nuint)input);
            Check((ulong)result==127UL, "sbyte-nuint-explicit-unchecked-False-1");
        }
        {
            sbyte input = (sbyte)(0);
            nuint result = unchecked((nuint)input);
            Check((ulong)result==0UL, "sbyte-nuint-explicit-unchecked-False-2");
        }
        {
            sbyte input = (sbyte)(1);
            nuint result = unchecked((nuint)input);
            Check((ulong)result==1UL, "sbyte-nuint-explicit-unchecked-False-3");
        }
        {
            sbyte input = (sbyte)(-1);
            nuint result = unchecked((nuint)input);
            Check((ulong)result==18446744073709551615UL, "sbyte-nuint-explicit-unchecked-False-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
