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
            float? input = -3.40282347e+38f;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                char? result = unchecked((char?)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "nullable-float-char-explicit-unchecked-lift-0");
        }
        {
            float? input = 3.40282347e+38f;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                char? result = unchecked((char?)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "nullable-float-char-explicit-unchecked-lift-1");
        }
        {
            float? input = -1.0f;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                char? result = unchecked((char?)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "nullable-float-char-explicit-unchecked-lift-5");
        }
        {
            float? input = 65536.0f;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                char? result = unchecked((char?)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "nullable-float-char-explicit-unchecked-lift-13");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
