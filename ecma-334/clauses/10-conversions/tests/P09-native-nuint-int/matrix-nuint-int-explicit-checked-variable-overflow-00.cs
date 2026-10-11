/*
Rules: P09-native-nuint-int
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
            nuint input = (nuint)(18446744073709551615UL);
            bool threw = false;
            try
            {
                int result = checked((int)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "nuint-int-explicit-checked-False-1");
        }
        {
            nuint input = (nuint)(2147483648UL);
            bool threw = false;
            try
            {
                int result = checked((int)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "nuint-int-explicit-checked-False-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
