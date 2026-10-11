/*
Rules: E8-3-3-simple-default-bits
Authority: ECMA-334 7th ed 8.3.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: float single = new float();
Into: float single = -1.0f;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        float single = new float(); double wide = new double();
        Check(BitConverter.SingleToInt32Bits(single) == 0 && BitConverter.DoubleToInt64Bits(wide) == 0, "floating-default-positive-zero-bits");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
