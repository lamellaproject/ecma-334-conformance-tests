/*
Rules: P09-native-decimal-nuint; P09-native-nullable-unwrap
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 4
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
            decimal? input = -79228162514264337593543950335m;
            bool threw = false;
            try
            {
                nuint result = unchecked((nuint)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "decimal-nuint-explicit-unchecked-unwrap-0");
        }
        {
            decimal? input = 79228162514264337593543950335m;
            bool threw = false;
            try
            {
                nuint result = unchecked((nuint)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "decimal-nuint-explicit-unchecked-unwrap-1");
        }
        {
            decimal? input = -1m;
            bool threw = false;
            try
            {
                nuint result = unchecked((nuint)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "decimal-nuint-explicit-unchecked-unwrap-4");
        }
        {
            decimal? input = 18446744073709551616m;
            bool threw = false;
            try
            {
                nuint result = unchecked((nuint)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "decimal-nuint-explicit-unchecked-unwrap-11");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
