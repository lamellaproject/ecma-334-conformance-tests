/*
Rules: E10-6-1-classification; E10-6-1-wrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 4
Generated: clauses/10-conversions/generators/standard-matrices.py
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
                ushort? result = checked((ushort?)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "nullable-double-ushort-explicit-checked-wrap-0");
        }
        {
            double input = 1.7976931348623157e+308d;
            bool threw = false;
            try
            {
                ushort? result = checked((ushort?)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "nullable-double-ushort-explicit-checked-wrap-1");
        }
        {
            double input = -1.0d;
            bool threw = false;
            try
            {
                ushort? result = checked((ushort?)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "nullable-double-ushort-explicit-checked-wrap-5");
        }
        {
            double input = 65536.0d;
            bool threw = false;
            try
            {
                ushort? result = checked((ushort?)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "nullable-double-ushort-explicit-checked-wrap-13");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
