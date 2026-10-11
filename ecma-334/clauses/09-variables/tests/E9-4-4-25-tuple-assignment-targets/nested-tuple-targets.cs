/*
Rules: E9-4-4-25-tuple-assignment-targets; E9-4-4-25-nontuple-assignment-target; E9-4-4-25-assigned-target-exit
Authority: ECMA-334 7th ed 9.4.4.25
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: (left, (middle, right)) = (12, (24, 36));
Into: (left, (_, right)) = (12, (24, 36));
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int left, middle, right;
        (left, (middle, right)) = (12, (24, 36));
        Check(left == 12, "outer-target-assigned");
        Check(middle == 24, "nested-first-target-assigned");
        Check(right == 36, "nested-second-target-assigned");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
