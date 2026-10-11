/*
Rules: E15-5-5-default-initial-field-value
Authority: ECMA-334 7th ed 15.5.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public double Value;
Into: public double Value = -0.0d;
*/
using System;
class Holder { public double Value; public static double Global; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    unsafe static long Bits(double value) { return *(long*)&value; }
    static void Main()
    {
        Holder value = new Holder();
        Check(Bits(value.Value) == 0L, "instance-double-default-bits");
        Check(Bits(Holder.Global) == 0L, "static-double-default-bits");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
