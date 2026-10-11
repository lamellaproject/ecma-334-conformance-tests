/*
Rules: P09-native-nint-ushort; P09-native-nullable-unwrap
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
            nint? input = (nint)(long.MinValue);
            bool threw = false;
            try
            {
                ushort result = checked((ushort)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "nint-ushort-explicit-checked-unwrap-0");
        }
        {
            nint? input = (nint)(9223372036854775807L);
            bool threw = false;
            try
            {
                ushort result = checked((ushort)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "nint-ushort-explicit-checked-unwrap-1");
        }
        {
            nint? input = (nint)(-1L);
            bool threw = false;
            try
            {
                ushort result = checked((ushort)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "nint-ushort-explicit-checked-unwrap-4");
        }
        {
            nint? input = (nint)(65536L);
            bool threw = false;
            try
            {
                ushort result = checked((ushort)input);
            }
            catch (OverflowException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "nint-ushort-explicit-checked-unwrap-7");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
