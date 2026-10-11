/*
Rules: E10-3-2-all-pairs; E10-3-2-char
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 2
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
            char input = (char)(65535);
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
            Check(threw, "char-byte-explicit-checked-variable-1");
        }
        {
            char input = (char)(256);
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
            Check(threw, "char-byte-explicit-checked-variable-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
