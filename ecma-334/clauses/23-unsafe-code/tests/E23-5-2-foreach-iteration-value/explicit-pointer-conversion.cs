/*
Rules: E23-5-2-foreach-iteration-value
Authority: ECMA-334 7th ed 23.5.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: foreach (short* current in items)
Into: foreach (short* current in new int*[0])
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int value = 43;
        int*[] items = { &value };
        int count = 0;
        foreach (short* current in items)
        {
            Check((void*)current == (void*)&value, "foreach-explicit-pointer-conversion");
            count++;
        }
        Check(count == 1, "converted-body-count");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
