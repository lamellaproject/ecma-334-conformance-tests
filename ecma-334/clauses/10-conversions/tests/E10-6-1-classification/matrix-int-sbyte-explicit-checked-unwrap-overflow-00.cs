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
            int? input = -2147483648;
            bool threw = false;
            try
            {
                sbyte result = checked((sbyte)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "nullable-int-sbyte-explicit-checked-unwrap-0");
        }
        {
            int? input = 2147483647;
            bool threw = false;
            try
            {
                sbyte result = checked((sbyte)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "nullable-int-sbyte-explicit-checked-unwrap-1");
        }
        {
            int? input = -129;
            bool threw = false;
            try
            {
                sbyte result = checked((sbyte)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "nullable-int-sbyte-explicit-checked-unwrap-5");
        }
        {
            int? input = 128;
            bool threw = false;
            try
            {
                sbyte result = checked((sbyte)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "nullable-int-sbyte-explicit-checked-unwrap-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
