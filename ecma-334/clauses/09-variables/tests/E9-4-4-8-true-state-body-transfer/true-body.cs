/*
Rules: E9-4-4-8-true-state-body-transfer
Authority: ECMA-334 7th ed 9.4.4.8
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: gate && (cell = 22) > 0
Into: gate || (cell = 22) > 0
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool gate = true;
        int cell, iterations = 0;
        while (gate && (cell = 22) > 0)
        {
            Check(cell == 22, "true-substate-at-body-entry");
            iterations++;
            gate = false;
        }
        Check(iterations == 1, "loop-runs-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
