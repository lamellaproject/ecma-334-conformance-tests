/*
Rules: E10-3-2-all-pairs; E10-3-2-double
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 3
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
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                long result = unchecked((long)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "double-long-explicit-unchecked-variable-0");
        }
        {
            double input = 1.7976931348623157e+308d;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                long result = unchecked((long)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "double-long-explicit-unchecked-variable-1");
        }
        {
            double input = 9.2233720368547758e+18d;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                long result = unchecked((long)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "double-long-explicit-unchecked-variable-12");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
