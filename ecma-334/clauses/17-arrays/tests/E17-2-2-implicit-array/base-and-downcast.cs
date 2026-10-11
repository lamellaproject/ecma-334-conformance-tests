/*
Rules: E17-2-2-implicit-array; E17-2-2-explicit-from-array; E17-2-2-any-array-instance
Authority: ECMA-334 7th ed 17.2.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: (int[,])erased
Into: erased
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[,] values = new int[2, 1];
        Array erased = values;
        int[,] restored = (int[,])erased;
        Check((object)erased == values, "implicit-base-identity");
        Check(restored == values, "explicit-downcast-identity");
        erased = new string[1];
        Check(erased is string[], "different-array-instance");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
