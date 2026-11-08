/*
Rules: E15-6-2-6-array-expanded-signature-precedence
Authority: ECMA-334 7th ed 15.6.2.6
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/E15-6-2-6-array-expanded-signature-precedence/inaccessible-applicable-scalar.cs.part
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
