/*
Rules: E10-3-2-checked-integral; E10-3-2-checked-overflow
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 16
Generated: clauses/10-conversions/generators/sample-matrix.py
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
            try
            {
                byte output = checked((byte)input);
                Check(false, "checked-int-byte-00");
            }
            catch (OverflowException)
            {
                Check(true, "checked-int-byte-00");
            }
            catch (Exception error)
            {
                Check(false, "checked-int-byte-00");
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
        }
        {
            int input = -257;
            try
            {
                byte output = checked((byte)input);
                Check(false, "checked-int-byte-01");
            }
            catch (OverflowException)
            {
                Check(true, "checked-int-byte-01");
            }
            catch (Exception error)
            {
                Check(false, "checked-int-byte-01");
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
        }
        {
            int input = -256;
            try
            {
                byte output = checked((byte)input);
                Check(false, "checked-int-byte-02");
            }
            catch (OverflowException)
            {
                Check(true, "checked-int-byte-02");
            }
            catch (Exception error)
            {
                Check(false, "checked-int-byte-02");
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
        }
        {
            int input = -129;
            try
            {
                byte output = checked((byte)input);
                Check(false, "checked-int-byte-03");
            }
            catch (OverflowException)
            {
                Check(true, "checked-int-byte-03");
            }
            catch (Exception error)
            {
                Check(false, "checked-int-byte-03");
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
        }
        {
            int input = -1;
            try
            {
                byte output = checked((byte)input);
                Check(false, "checked-int-byte-04");
            }
            catch (OverflowException)
            {
                Check(true, "checked-int-byte-04");
            }
            catch (Exception error)
            {
                Check(false, "checked-int-byte-04");
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
        }
        {
            int input = 0;
            try
            {
                byte output = checked((byte)input);
                Check(output == 0, "checked-int-byte-05");
            }
            catch (OverflowException)
            {
                Check(false, "checked-int-byte-05");
            }
            catch (Exception error)
            {
                Check(false, "checked-int-byte-05");
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
        }
        {
            int input = 1;
            try
            {
                byte output = checked((byte)input);
                Check(output == 1, "checked-int-byte-06");
            }
            catch (OverflowException)
            {
                Check(false, "checked-int-byte-06");
            }
            catch (Exception error)
            {
                Check(false, "checked-int-byte-06");
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
        }
        {
            int input = 2;
            try
            {
                byte output = checked((byte)input);
                Check(output == 2, "checked-int-byte-07");
            }
            catch (OverflowException)
            {
                Check(false, "checked-int-byte-07");
            }
            catch (Exception error)
            {
                Check(false, "checked-int-byte-07");
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
        }
        {
            int input = 127;
            try
            {
                byte output = checked((byte)input);
                Check(output == 127, "checked-int-byte-08");
            }
            catch (OverflowException)
            {
                Check(false, "checked-int-byte-08");
            }
            catch (Exception error)
            {
                Check(false, "checked-int-byte-08");
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
        }
        {
            int input = 128;
            try
            {
                byte output = checked((byte)input);
                Check(output == 128, "checked-int-byte-09");
            }
            catch (OverflowException)
            {
                Check(false, "checked-int-byte-09");
            }
            catch (Exception error)
            {
                Check(false, "checked-int-byte-09");
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
        }
        {
            int input = 254;
            try
            {
                byte output = checked((byte)input);
                Check(output == 254, "checked-int-byte-10");
            }
            catch (OverflowException)
            {
                Check(false, "checked-int-byte-10");
            }
            catch (Exception error)
            {
                Check(false, "checked-int-byte-10");
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
        }
        {
            int input = 255;
            try
            {
                byte output = checked((byte)input);
                Check(output == 255, "checked-int-byte-11");
            }
            catch (OverflowException)
            {
                Check(false, "checked-int-byte-11");
            }
            catch (Exception error)
            {
                Check(false, "checked-int-byte-11");
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
        }
        {
            int input = 256;
            try
            {
                byte output = checked((byte)input);
                Check(false, "checked-int-byte-12");
            }
            catch (OverflowException)
            {
                Check(true, "checked-int-byte-12");
            }
            catch (Exception error)
            {
                Check(false, "checked-int-byte-12");
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
        }
        {
            int input = 257;
            try
            {
                byte output = checked((byte)input);
                Check(false, "checked-int-byte-13");
            }
            catch (OverflowException)
            {
                Check(true, "checked-int-byte-13");
            }
            catch (Exception error)
            {
                Check(false, "checked-int-byte-13");
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
        }
        {
            int input = 65536;
            try
            {
                byte output = checked((byte)input);
                Check(false, "checked-int-byte-14");
            }
            catch (OverflowException)
            {
                Check(true, "checked-int-byte-14");
            }
            catch (Exception error)
            {
                Check(false, "checked-int-byte-14");
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
        }
        {
            int input = 2147483647;
            try
            {
                byte output = checked((byte)input);
                Check(false, "checked-int-byte-15");
            }
            catch (OverflowException)
            {
                Check(true, "checked-int-byte-15");
            }
            catch (Exception error)
            {
                Check(false, "checked-int-byte-15");
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
