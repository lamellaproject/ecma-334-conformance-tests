/*
Rules: E10-3-2-all-pairs; E10-3-2-double; E12-23-numeric
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
            const double input = -1.7976931348623157e+308d;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                ushort result = unchecked((ushort)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "double-ushort-explicit-unchecked-constant-0");
        }
        {
            const double input = 1.7976931348623157e+308d;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                ushort result = unchecked((ushort)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "double-ushort-explicit-unchecked-constant-1");
        }
        {
            const double input = -1.0d;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                ushort result = unchecked((ushort)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "double-ushort-explicit-unchecked-constant-5");
        }
        {
            const double input = 65536.0d;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                ushort result = unchecked((ushort)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "double-ushort-explicit-unchecked-constant-13");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
