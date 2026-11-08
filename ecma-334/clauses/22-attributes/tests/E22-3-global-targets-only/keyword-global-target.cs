/*
Rules: E22-3-global-targets-only
Authority: ECMA-334 7th ed 22.3
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/E22-3-global-targets-only/keyword-global-target.cs.part
Mutate: [while: Marker]
Into: [assembly: Marker]
*/
using System;
[while: Marker]
namespace Space { }
class MarkerAttribute : Attribute { }
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
        int value = 41;
        Check(value == 41, "global-extension-program-accepted");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
