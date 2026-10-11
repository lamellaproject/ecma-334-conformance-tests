/*
Rules: E10-6-1-classification; E10-6-1-unwrap
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
                char result = unchecked((char)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "nullable-double-char-explicit-unchecked-unwrap-0");
        }
        {
            double? input = 1.7976931348623157e+308d;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                char result = unchecked((char)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "nullable-double-char-explicit-unchecked-unwrap-1");
        }
        {
            double? input = -1.0d;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                char result = unchecked((char)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "nullable-double-char-explicit-unchecked-unwrap-5");
        }
        {
            double? input = 65536.0d;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                char result = unchecked((char)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "nullable-double-char-explicit-unchecked-unwrap-13");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
