/*
Rules: P09-native-nint-short
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 4
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
            nint input = (nint)(long.MinValue);
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
            Check(threw, "nint-short-explicit-checked-False-0");
        }
        {
            nint input = (nint)(9223372036854775807L);
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
            Check(threw, "nint-short-explicit-checked-False-1");
        }
        {
            nint input = (nint)(-32769L);
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
            Check(threw, "nint-short-explicit-checked-False-5");
        }
        {
            nint input = (nint)(32768L);
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
            Check(threw, "nint-short-explicit-checked-False-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
