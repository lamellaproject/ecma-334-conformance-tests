/*
Rules: E7-3-statement-local-spaces; E7-3-disjoint-local-name-reuse
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: for (int index = 2; index < 4; index++)
Into: for (int sum = 2; sum < 4; sum++)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int sum = 0;
        for (int index = 0; index < 2; index++) sum += index;
        for (int index = 2; index < 4; index++) sum += index;
        Check(sum == 6, "independent-iteration-spaces");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
