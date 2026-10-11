/*
Rules: E7-10-thread-data-dependence; E7-10-execution-reordering
Authority: ECMA-334 7th ed 7.10
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: int prior = cell++;
Into: int prior = ++cell;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int cell = 5;
        int prior = cell++;
        int doubled = cell * 2;
        cell = prior + doubled;
        int left = 7 * 3, right = 8 + 9;
        Check(prior == 5 && doubled == 12, "dependent-values-follow-original-program-order");
        Check(cell == 17, "later-assignment-uses-both-prior-computations");
        // Reordering independent pure calculations is permitted; no physical execution order is asserted.
        Check(left == 21 && right == 17, "independent-calculations-retain-values-under-any-permitted-reordering");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
