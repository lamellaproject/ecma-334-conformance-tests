/*
Rules: E7-7-1-expanded-construct-variable-scope
Authority: ECMA-334 7th ed 7.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: foreach (int value in
Into: foreach (int renamed in
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int sum = 0;
        foreach (int value in new int[] { 2, 4, 8 }) { sum += value; }
        Check(sum == 14, "iteration-variable-visible-in-expanded-foreach-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
