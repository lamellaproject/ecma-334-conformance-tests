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
            float? input = -3.40282347e+38f;
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
            Check(threw, "nullable-float-short-explicit-checked-unwrap-0");
        }
        {
            float? input = 3.40282347e+38f;
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
            Check(threw, "nullable-float-short-explicit-checked-unwrap-1");
        }
        {
            float? input = -32769.0f;
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
            Check(threw, "nullable-float-short-explicit-checked-unwrap-11");
        }
        {
            float? input = 32768.0f;
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
            Check(threw, "nullable-float-short-explicit-checked-unwrap-16");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
