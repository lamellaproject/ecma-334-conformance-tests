/*
Rules: E10-2-9-ed3-nullable-null-box-instance
Authority: ECMA-334 3rd ed 11.3.1
Version: ISO-2
Expected: run
Stdout: OK 1
Version-Witness: version-witnesses/E10-2-9-ed3-nullable-null-box-instance/empty-nullable-object.cs.part
Mutate: object boxed = seed;
Into: object boxed = null;
*/
// ECMA-334 3rd ed 11.3.1, p. 114 (PDF p. 134).
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static int Main()
    {
        int? seed = null;
        object boxed = seed;
        Check(boxed != (object)null, "empty-nullable-instance");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
