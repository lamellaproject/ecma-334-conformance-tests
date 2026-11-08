/*
Rules: E12-6-3-ed3-consistent-type-inference
Authority: ECMA-334 3rd ed 25.6.4
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E12-6-3-ed3-consistent-type-inference/array-element-arguments.cs.part
Mutate: Merge(left, right)
Into: Merge<object>(left, right)
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
    static T[] Merge<T>(T[] left, T[] right) { return left; }
    static int Main()
    {
        string[] left = new string[0];
        object[] right = new object[0];
        object[] value = Merge(left, right);
        Check(value == left, "array-merge");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
