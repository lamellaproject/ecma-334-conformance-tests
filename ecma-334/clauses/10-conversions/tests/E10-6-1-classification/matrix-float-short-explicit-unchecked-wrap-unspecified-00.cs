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
            float input = -3.40282347e+38f;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                short? result = unchecked((short?)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "nullable-float-short-explicit-unchecked-wrap-0");
        }
        {
            float input = 3.40282347e+38f;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                short? result = unchecked((short?)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "nullable-float-short-explicit-unchecked-wrap-1");
        }
        {
            float input = -32769.0f;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                short? result = unchecked((short?)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "nullable-float-short-explicit-unchecked-wrap-11");
        }
        {
            float input = 32768.0f;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                short? result = unchecked((short?)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "nullable-float-short-explicit-unchecked-wrap-16");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
