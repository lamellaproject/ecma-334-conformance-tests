/*
Rules: E12-6-4-7-ed3-no-nullable-signed-tie-break
Authority: ECMA-334 3rd ed 14.4.2.3
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E12-6-4-7-ed3-no-nullable-signed-tie-break/nullable-integral-targets.cs.part
Mutate: Choose(seed)
Into: Choose((short?)seed)
*/
// ECMA-334 3rd ed 14.4.2.3, p. 162 (PDF p. 182).
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static int Choose(short? value) { return 1; }
    static int Choose(ushort? value) { return 2; }
    static int Main()
    {
        byte? seed = 26;
        int choice = Choose(seed);
        Check(choice == 1, "nullable-target-choice");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
