/*
Rules: P09-native-double-nint; P09-native-nullable-lift
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 3
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
            double? input = -1.7976931348623157e+308d;
            bool threw = false;
            try
            {
                nint? result = checked((nint?)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "double-nint-explicit-checked-lift-0");
        }
        {
            double? input = 1.7976931348623157e+308d;
            bool threw = false;
            try
            {
                nint? result = checked((nint?)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "double-nint-explicit-checked-lift-1");
        }
        {
            double? input = 9.2233720368547758e+18d;
            bool threw = false;
            try
            {
                nint? result = checked((nint?)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "double-nint-explicit-checked-lift-12");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
