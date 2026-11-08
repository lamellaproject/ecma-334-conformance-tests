/*
Rules: E10-2-9-ed3-nullable-box-dynamic-type
Authority: ECMA-334 3rd ed 11.3.1
Version: ISO-2
Expected: run
Stdout: OK 2
Version-Witness: version-witnesses/E10-2-9-ed3-nullable-box-dynamic-type/nullable-box-type.cs.part
Mutate: object boxed = seed;
Into: object boxed = seed.Value;
*/
// ECMA-334 3rd ed 11.3.1, p. 115 (PDF p. 135).
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
        int? seed = 57;
        object boxed = seed;
        Check(boxed != (object)null, "nonnull-box");
        Check(!(boxed is int), "nullable-dynamic-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
