/*
Rules: E15-5-5-default-initial-field-value
Authority: ECMA-334 7th ed 15.5.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public decimal Value;
Into: public decimal Value = 0.00m;
*/
using System;
class Holder { public decimal Value; public static decimal Global; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool AllZero(decimal value)
    {
        // GetBits observes the required zero sign and scale as well as the numeric zero.
        int[] bits = decimal.GetBits(value);
        return value == 0m && bits.Length == 4 && bits[0] == 0 && bits[1] == 0 && bits[2] == 0 && bits[3] == 0;
    }
    static void Main()
    {
        Check(AllZero(new Holder().Value), "instance-decimal-default-zero-scale");
        Check(AllZero(Holder.Global), "static-decimal-default-zero-scale");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
