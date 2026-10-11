/*
Rules: E9-2-9-foreach-local-category; E9-2-9-foreach-local-initially-assigned; E9-4-2-foreach-variable-assigned
Authority: ECMA-334 7th ed 9.2.9
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: new int[] { 21, 35 }
Into: new int[] { 0, 0 }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int index = 0;
        foreach (int cell in new int[] { 21, 35 })
        {
            Check(cell == (index == 0 ? 21 : 35), "iteration-local-initially-readable");
            index++;
        }
        Check(index == 2, "iteration-count");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
