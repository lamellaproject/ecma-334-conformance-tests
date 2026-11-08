/*
Rules: E12-12-13-target-type
Authority: ECMA-334 7th ed 12.12.13
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/E12-12-13-target-type/pointer-target.cs.part
Mutate: source as int*
Into: (int*)null
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
    static unsafe int Main()
    {
        object source = null;
        int* result = source as int*;
        Check(result == null, "pointer-target-repair");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
