/*
Rules: E10-6-1-classification; E10-6-1-wrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 3
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
            bool threw = false;
            try
            {
                int? result = checked((int?)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "nullable-float-int-explicit-checked-wrap-0");
        }
        {
            float input = 3.40282347e+38f;
            bool threw = false;
            try
            {
                int? result = checked((int?)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "nullable-float-int-explicit-checked-wrap-1");
        }
        {
            float input = 2.14748365e+09f;
            bool threw = false;
            try
            {
                int? result = checked((int?)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "nullable-float-int-explicit-checked-wrap-12");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
