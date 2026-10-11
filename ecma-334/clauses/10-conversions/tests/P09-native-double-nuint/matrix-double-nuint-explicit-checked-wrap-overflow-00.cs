/*
Rules: P09-native-double-nuint; P09-native-nullable-wrap
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
            double input = -1.7976931348623157e+308d;
            bool threw = false;
            try
            {
                nuint? result = checked((nuint?)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "double-nuint-explicit-checked-wrap-0");
        }
        {
            double input = 1.7976931348623157e+308d;
            bool threw = false;
            try
            {
                nuint? result = checked((nuint?)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "double-nuint-explicit-checked-wrap-1");
        }
        {
            double input = -1.0d;
            bool threw = false;
            try
            {
                nuint? result = checked((nuint?)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "double-nuint-explicit-checked-wrap-5");
        }
        {
            double input = 1.8446744073709552e+19d;
            bool threw = false;
            try
            {
                nuint? result = checked((nuint?)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "double-nuint-explicit-checked-wrap-11");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
