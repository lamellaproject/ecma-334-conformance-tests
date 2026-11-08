/*
Rules: E12-12-7-ed3-bidirectional-reference-conversions
Authority: ECMA-334 3rd ed 14.9.6
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E12-12-7-ed3-bidirectional-reference-conversions/object-and-null-type.cs.part
Mutate: item == null
Into: item == (object)null
*/
// ECMA-334 3rd ed 14.9.6, p. 207 (PDF p. 227).
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
        object item = new object();
        Check(!(item == null), "nonnull-object");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
