/*
Rules: E15-10-3-left-shift-first-type
Authority: ECMA-334 7th ed 15.10.3
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/E15-10-3-left-shift-first-type/qualified-namesake-operand.cs.part
Mutate: Remote.Dial item
Into: Dial item
*/
using System;
namespace Remote { class Dial { } }
class Dial { public static int operator <<(Remote.Dial item, int count) { return count + 3; } }
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
        Dial item = new Dial();
        Check(item != null, "containing-type-repair");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
