/*
Rules: P09-native-decimal-nuint
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 10
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
            decimal input = 0m;
            nuint result = unchecked((nuint)input);
            Check((ulong)result==0UL, "decimal-nuint-explicit-unchecked-False-2");
        }
        {
            decimal input = 1m;
            nuint result = unchecked((nuint)input);
            Check((ulong)result==1UL, "decimal-nuint-explicit-unchecked-False-3");
        }
        {
            decimal input = 0.1m;
            nuint result = unchecked((nuint)input);
            Check((ulong)result==0UL, "decimal-nuint-explicit-unchecked-False-5");
        }
        {
            decimal input = -0.1m;
            nuint result = unchecked((nuint)input);
            Check((ulong)result==0UL, "decimal-nuint-explicit-unchecked-False-6");
        }
        {
            decimal input = 1E-28m;
            nuint result = unchecked((nuint)input);
            Check((ulong)result==0UL, "decimal-nuint-explicit-unchecked-False-7");
        }
        {
            decimal input = -1E-28m;
            nuint result = unchecked((nuint)input);
            Check((ulong)result==0UL, "decimal-nuint-explicit-unchecked-False-8");
        }
        {
            decimal input = 18446744073709551614m;
            nuint result = unchecked((nuint)input);
            Check((ulong)result==18446744073709551614UL, "decimal-nuint-explicit-unchecked-False-9");
        }
        {
            decimal input = 18446744073709551615m;
            nuint result = unchecked((nuint)input);
            Check((ulong)result==18446744073709551615UL, "decimal-nuint-explicit-unchecked-False-10");
        }
        {
            decimal input = -0.75m;
            nuint result = unchecked((nuint)input);
            Check((ulong)result==0UL, "decimal-nuint-explicit-unchecked-False-12");
        }
        {
            decimal input = 18446744073709551615.75m;
            nuint result = unchecked((nuint)input);
            Check((ulong)result==18446744073709551615UL, "decimal-nuint-explicit-unchecked-False-13");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
