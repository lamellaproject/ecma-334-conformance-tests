/*
Rules: E12-6-4-5-ed3-no-anonymous-return-preference
Authority: ECMA-334 3rd ed 14.4.2.3
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E12-6-4-5-ed3-no-anonymous-return-preference/anonymous-return-tie.cs.part
Mutate: Choose(delegate { return (short)31; })
Into: Choose(new Narrow(delegate { return (short)31; }))
*/
// ECMA-334 3rd ed 14.4.2.3, p. 162 (PDF p. 182).
using System;
delegate short Narrow();
delegate long Wide();
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static int Choose(Narrow action) { return 1; }
    static int Choose(Wide action) { return 2; }
    static int Main()
    {
        int choice = Choose(delegate { return (short)31; });
        Check(choice == 1, "anonymous-return-choice");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
