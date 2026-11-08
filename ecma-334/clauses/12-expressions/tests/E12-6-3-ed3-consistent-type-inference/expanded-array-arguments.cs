/*
Rules: E12-6-3-ed3-consistent-type-inference
Authority: ECMA-334 3rd ed 25.6.4
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E12-6-3-ed3-consistent-type-inference/expanded-array-arguments.cs.part
Mutate: Bundle(left, right)
Into: Bundle<int>(left, right)
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
    static T[] Bundle<T>(params T[] values) { return values; }
    static int Main()
    {
        short left = 21;
        int right = 53;
        int[] values = Bundle(left, right);
        Check(values.Length == 2 && values[0] == 21 && values[1] == 53, "expanded-merge");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
