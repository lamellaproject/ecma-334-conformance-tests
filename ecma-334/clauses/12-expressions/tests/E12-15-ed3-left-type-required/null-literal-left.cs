/*
Rules: E12-15-ed3-left-type-required
Authority: ECMA-334 3rd ed 14.12
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E12-15-ed3-left-type-required/null-literal-left.cs.part
Mutate: null ?? "juniper"
Into: typed ?? "juniper"
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
    static int Main()
    {
        string typed = null;
        Check((typed ?? "juniper") == "juniper", "typed-null-control");
        string result = null ?? "juniper";
        Check(result == "juniper", "null-literal-coalescing");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
