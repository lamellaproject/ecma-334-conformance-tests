/*
Rules: P09-native-nuint-byte
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 2
Generated: clauses/10-conversions/generators/native-matrices.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        {
            nuint input = (nuint)(18446744073709551615UL);
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
            Check(threw, "nuint-byte-explicit-checked-False-1");
        }
        {
            nuint input = (nuint)(256UL);
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
            Check(threw, "nuint-byte-explicit-checked-False-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
