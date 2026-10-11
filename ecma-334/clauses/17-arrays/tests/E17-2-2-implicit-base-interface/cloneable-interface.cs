/*
Rules: E17-2-2-implicit-base-interface; E17-2-2-explicit-from-interface
Authority: ECMA-334 7th ed 17.2.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: (int[])erased
Into: erased
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] values = new int[2];
        ICloneable erased = values;
        int[] restored = (int[])erased;
        Check((object)erased == values, "implicit-base-interface");
        Check(restored == values, "explicit-from-base-interface");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
