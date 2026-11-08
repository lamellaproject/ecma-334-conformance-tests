/*
Rules: E22-3-ed3-global-extension-target
Authority: ECMA-334 3rd ed 24.2
Version: ISO-2
Expected: run
Stdout: OK 1
Version-Witness: version-witnesses/E22-3-ed3-global-extension-target/keyword-global-target.cs.part
Mutate: [while: Marker]
Into: [event: Marker]
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
