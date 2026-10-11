/*
Rules: E7-3-disjoint-local-name-reuse; E7-3-nested-local-spaces; E7-3-statement-local-spaces; E7-3-local-space-name-sources
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int value = 23;
Into: int sum = 23;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int sum = 0;
        { int value = 17; sum += value; }
        { int value = 23; sum += value; }
        Check(sum == 40, "disjoint-local-spaces-reuse-name");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
