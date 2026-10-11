/*
Rules: E10-6-1-classification; E10-6-1-nonnull
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
            decimal? input = -79228162514264337593543950335m;
            bool threw = false;
            try
            {
                short? result = unchecked((short?)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "nullable-decimal-short-explicit-unchecked-lift-0");
        }
        {
            decimal? input = 79228162514264337593543950335m;
            bool threw = false;
            try
            {
                short? result = unchecked((short?)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "nullable-decimal-short-explicit-unchecked-lift-1");
        }
        {
            decimal? input = -32769m;
            bool threw = false;
            try
            {
                short? result = unchecked((short?)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "nullable-decimal-short-explicit-unchecked-lift-9");
        }
        {
            decimal? input = 32768m;
            bool threw = false;
            try
            {
                short? result = unchecked((short?)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "nullable-decimal-short-explicit-unchecked-lift-14");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
