/*
Rules: E10-6-1-classification; E10-6-1-wrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 1
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
            float input = float.NegativeInfinity;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                byte? result = unchecked((byte?)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "nullable-float-byte-explicit-unchecked-wrap-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
