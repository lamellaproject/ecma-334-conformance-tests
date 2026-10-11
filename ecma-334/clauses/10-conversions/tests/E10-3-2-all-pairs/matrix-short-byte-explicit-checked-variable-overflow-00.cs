/*
Rules: E10-3-2-all-pairs; E10-3-2-short
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
            short input = (short)(-32768);
            bool threw = false;
            try
            {
                byte result = checked((byte)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "short-byte-explicit-checked-variable-0");
        }
        {
            short input = (short)(32767);
            bool threw = false;
            try
            {
                byte result = checked((byte)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "short-byte-explicit-checked-variable-1");
        }
        {
            short input = (short)(-1);
            bool threw = false;
            try
            {
                byte result = checked((byte)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "short-byte-explicit-checked-variable-4");
        }
        {
            short input = (short)(256);
            bool threw = false;
            try
            {
                byte result = checked((byte)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "short-byte-explicit-checked-variable-7");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
