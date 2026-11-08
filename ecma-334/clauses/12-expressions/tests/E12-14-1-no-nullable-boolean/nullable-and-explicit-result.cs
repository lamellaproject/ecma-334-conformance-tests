/*
Rules: E12-14-1-no-nullable-boolean
Authority: ECMA-334 7th ed 12.14.1
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/E12-14-1-no-nullable-boolean/nullable-and-explicit-result.cs.part
Mutate: left && right
Into: left & right
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        bool? left = null, right = true;
        bool? result = left && right;
        Check(result == null, "nullable-conditional-and");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
