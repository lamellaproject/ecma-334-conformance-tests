/*
Rules: E10-3-2-checked-integral; E10-3-2-checked-overflow
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: checked((byte)large)
Into: unchecked((byte)large)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int fit = 197;
        byte result = checked((byte)fit);
        Check(result == 197, "checked-byte/in-range");
        int large = 256;
        try
        {
            byte overflow = checked((byte)large);
            Check(false, "checked-byte/required-exception");
        }
        catch (OverflowException) { Check(true, "checked-byte/required-exception"); }
        catch (Exception error)
        {
            Check(false, "checked-byte/exception-type");
            Console.WriteLine("EXCEPTION " + error.GetType().FullName);
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
