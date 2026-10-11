/*
Rules: E17-2-1-null-value; E17-2-2-null-value
Authority: ECMA-334 7th ed 17.2.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int[,] values = null
Into: int[,] values = new int[0, 0]
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[,] values = null;
        Array erased = values;
        Check(values == null, "array-null");
        Check(erased == null, "base-null");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
