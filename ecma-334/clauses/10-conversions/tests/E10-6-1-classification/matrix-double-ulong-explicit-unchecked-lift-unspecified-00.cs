/*
Rules: E10-6-1-classification; E10-6-1-nonnull
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
            double? input = -1.7976931348623157e+308d;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                ulong? result = unchecked((ulong?)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "nullable-double-ulong-explicit-unchecked-lift-0");
        }
        {
            double? input = 1.7976931348623157e+308d;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                ulong? result = unchecked((ulong?)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "nullable-double-ulong-explicit-unchecked-lift-1");
        }
        {
            double? input = -1.0d;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                ulong? result = unchecked((ulong?)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "nullable-double-ulong-explicit-unchecked-lift-5");
        }
        {
            double? input = 1.8446744073709552e+19d;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                ulong? result = unchecked((ulong?)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "nullable-double-ulong-explicit-unchecked-lift-11");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
