/*
Rules: E12-15-to-right-type
Authority: ECMA-334 7th ed 12.15
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: null ?? "juniper"
Into: "fir" ?? "juniper"
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
