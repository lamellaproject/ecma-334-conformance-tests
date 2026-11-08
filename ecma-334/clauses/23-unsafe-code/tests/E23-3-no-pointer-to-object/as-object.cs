/*
Rules: E23-3-no-pointer-to-object
Authority: ECMA-334 7th ed 23.3
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/E23-3-no-pointer-to-object/as-object.cs.part
Mutate: pointer as object
Into: (object)(long)pointer
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
        int* pointer = null;
        object result = pointer as object;
        Check(result != null && (long)result == 0, "integral-boxing-repair");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
