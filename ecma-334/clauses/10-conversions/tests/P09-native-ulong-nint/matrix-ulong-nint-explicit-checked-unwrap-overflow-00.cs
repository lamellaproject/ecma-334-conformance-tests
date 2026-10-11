/*
Rules: P09-native-ulong-nint; P09-native-nullable-unwrap
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 2
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
            ulong? input = 18446744073709551615UL;
            bool threw = false;
            try
            {
                nint result = checked((nint)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "ulong-nint-explicit-checked-unwrap-1");
        }
        {
            ulong? input = 9223372036854775808UL;
            bool threw = false;
            try
            {
                nint result = checked((nint)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "ulong-nint-explicit-checked-unwrap-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
