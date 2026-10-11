/*
Rules: E17-4-foreach
Authority: ECMA-334 7th ed 17.4
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: foreach (int item in values)
Into: foreach (int item in new int[0])
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] values = { 3, 6, 9 }; int count = 0;
        foreach (int item in values)
        {
            Check(item == (count + 1) * 3, "enumerated-element");
            count++;
        }
        Check(count == 3, "all-elements-enumerated");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
