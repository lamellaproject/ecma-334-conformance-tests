/*
Rules: E10-3-2-all-pairs; E10-3-2-double
Authority: ECMA-334 7th ed 10.3.2
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
                short result = checked((short)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "double-short-explicit-checked-variable-0");
        }
        {
            double input = 1.7976931348623157e+308d;
            bool threw = false;
            try
            {
                short result = checked((short)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "double-short-explicit-checked-variable-1");
        }
        {
            double input = -32769.0d;
            bool threw = false;
            try
            {
                short result = checked((short)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "double-short-explicit-checked-variable-11");
        }
        {
            double input = 32768.0d;
            bool threw = false;
            try
            {
                short result = checked((short)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "double-short-explicit-checked-variable-16");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
