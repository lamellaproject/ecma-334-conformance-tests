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
            int input = -2147483648;
            bool threw = false;
            try
            {
                char? result = checked((char?)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "nullable-int-char-explicit-checked-wrap-0");
        }
        {
            int input = 2147483647;
            bool threw = false;
            try
            {
                char? result = checked((char?)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "nullable-int-char-explicit-checked-wrap-1");
        }
        {
            int input = -1;
            bool threw = false;
            try
            {
                char? result = checked((char?)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "nullable-int-char-explicit-checked-wrap-4");
        }
        {
            int input = 65536;
            bool threw = false;
            try
            {
                char? result = checked((char?)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "nullable-int-char-explicit-checked-wrap-7");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
