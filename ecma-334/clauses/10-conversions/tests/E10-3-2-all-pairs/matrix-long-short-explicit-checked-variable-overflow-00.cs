/*
Rules: E10-3-2-all-pairs; E10-3-2-long
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
            long input = long.MinValue;
            bool threw = false;
            try
            {
                short result = checked((short)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "long-short-explicit-checked-variable-0");
        }
        {
            long input = 9223372036854775807L;
            bool threw = false;
            try
            {
                short result = checked((short)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "long-short-explicit-checked-variable-1");
        }
        {
            long input = -32769L;
            bool threw = false;
            try
            {
                short result = checked((short)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "long-short-explicit-checked-variable-5");
        }
        {
            long input = 32768L;
            bool threw = false;
            try
            {
                short result = checked((short)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "long-short-explicit-checked-variable-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
