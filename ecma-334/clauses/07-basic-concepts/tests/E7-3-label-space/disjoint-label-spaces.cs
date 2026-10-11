/*
Rules: E7-3-label-space; E7-3-label-declaration-names; E7-3-goto-label-references
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: target: goto second;
Into: renamed: goto second;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int sum = 0;
        { goto target; target: sum += 2; }
        { goto target; target: goto second; second: sum += 3; }
        Check(sum == 5, "disjoint-label-spaces-reuse-target");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
