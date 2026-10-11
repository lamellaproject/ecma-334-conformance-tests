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
                uint result = checked((uint)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "double-uint-explicit-checked-variable-0");
        }
        {
            double input = 1.7976931348623157e+308d;
            bool threw = false;
            try
            {
                uint result = checked((uint)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "double-uint-explicit-checked-variable-1");
        }
        {
            double input = -1.0d;
            bool threw = false;
            try
            {
                uint result = checked((uint)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "double-uint-explicit-checked-variable-5");
        }
        {
            double input = 4294967296.0d;
            bool threw = false;
            try
            {
                uint result = checked((uint)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "double-uint-explicit-checked-variable-13");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
