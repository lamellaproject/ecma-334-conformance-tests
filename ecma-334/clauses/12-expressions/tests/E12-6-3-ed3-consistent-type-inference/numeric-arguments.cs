/*
Rules: E12-6-3-ed3-consistent-type-inference
Authority: ECMA-334 3rd ed 25.6.4
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E12-6-3-ed3-consistent-type-inference/numeric-arguments.cs.part
Mutate: Merge(left, right)
Into: Merge<int>(left, right)
*/
// ECMA-334 3rd ed 25.6.4, p. 398 (PDF p. 418).
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static T Merge<T>(T left, T right) { return left; }
    static int Main()
    {
        short left = 19;
        int right = 46;
        int value = Merge(left, right);
        Check(value == 19, "numeric-merge");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
