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
            short input = (short)(-32768);
            bool threw = false;
            try
            {
                sbyte? result = checked((sbyte?)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "nullable-short-sbyte-explicit-checked-wrap-0");
        }
        {
            short input = (short)(32767);
            bool threw = false;
            try
            {
                sbyte? result = checked((sbyte?)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "nullable-short-sbyte-explicit-checked-wrap-1");
        }
        {
            short input = (short)(-129);
            bool threw = false;
            try
            {
                sbyte? result = checked((sbyte?)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "nullable-short-sbyte-explicit-checked-wrap-5");
        }
        {
            short input = (short)(128);
            bool threw = false;
            try
            {
                sbyte? result = checked((sbyte?)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "nullable-short-sbyte-explicit-checked-wrap-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
