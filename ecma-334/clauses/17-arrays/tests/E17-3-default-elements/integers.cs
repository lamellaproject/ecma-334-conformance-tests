/*
Rules: E17-3-default-elements
Authority: ECMA-334 7th ed 17.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new int[2]
Into: new int[] { 1, 0 }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] values = new int[2];
        Check(values[0] == 0, "first-default");
        Check(values[1] == 0, "last-default");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
