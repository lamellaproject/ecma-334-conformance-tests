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
                ushort result = unchecked((ushort)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "float-ushort-explicit-unchecked-constant-0");
        }
        {
            const float input = 3.40282347e+38f;
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
            Check(completed, "float-ushort-explicit-unchecked-constant-1");
        }
        {
            const float input = -1.0f;
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
            Check(completed, "float-ushort-explicit-unchecked-constant-5");
        }
        {
            const float input = 65536.0f;
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
            Check(completed, "float-ushort-explicit-unchecked-constant-13");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
