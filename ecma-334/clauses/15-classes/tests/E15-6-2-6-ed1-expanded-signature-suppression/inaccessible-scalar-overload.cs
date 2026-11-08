/*
Rules: E15-6-2-6-ed1-expanded-signature-suppression
Authority: ECMA-334 1st ed 17.5.1.4
Version: ISO-1
Expected: reject
Version-Witness: version-witnesses/E15-6-2-6-ed1-expanded-signature-suppression/inaccessible-scalar-overload.cs.part
Mutate: private static int Choose(int scalar)
Into: private static int Choose(long scalar)
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
    class Selector
    {
        public static int Choose(params int[] packed) { return packed.Length * 31; }
        private static int Choose(int scalar) { return 31; }
    }
    static int Main()
    {
        Check(Selector.Choose(9) == 31, "private-signature-suppresses-expansion");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
