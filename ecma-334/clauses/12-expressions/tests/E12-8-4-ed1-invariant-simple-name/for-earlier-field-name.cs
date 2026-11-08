/*
Rules: E12-8-4-ed1-invariant-simple-name
Authority: ECMA-334 1st ed 14.5.2.1
Version: ISO-1
Expected: reject
Version-Witness: version-witnesses/E12-8-4-ed1-invariant-simple-name/for-earlier-field-name.cs.part
Mutate: copied = source
Into: copied = Program.source
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
    static int source = 17;
    static int Main()
    {
        int observed = 0;
        for (int copied = source, source = 2; source < 3; source++) observed = copied;
        Check(observed == 17, "qualified-field-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
