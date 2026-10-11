/*
Rules: E23-5-2-foreach-temporaries-hidden
Authority: ECMA-334 7th ed 23.5.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: foreach (int* current in a)
Into: foreach (int* current in new int*[0, 0])
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int*[,] a = new int*[1, 1];
        int i0 = 17, i1 = 23;
        foreach (int* current in a)
        {
            Check(i0 == 17 && i1 == 23, "foreach-does-not-shadow-source");
        }
        Check(i0 == 17 && i1 == 23 && a.Length == 1, "foreach-does-not-change-source");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
