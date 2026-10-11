/*
Rules: E10-3-2-all-pairs; E10-3-2-float; E12-23-numeric
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
            const float input = -3.40282347e+38f;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                short result = unchecked((short)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "float-short-explicit-unchecked-constant-0");
        }
        {
            const float input = 3.40282347e+38f;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                short result = unchecked((short)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "float-short-explicit-unchecked-constant-1");
        }
        {
            const float input = -32769.0f;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                short result = unchecked((short)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "float-short-explicit-unchecked-constant-11");
        }
        {
            const float input = 32768.0f;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                short result = unchecked((short)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "float-short-explicit-unchecked-constant-16");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
