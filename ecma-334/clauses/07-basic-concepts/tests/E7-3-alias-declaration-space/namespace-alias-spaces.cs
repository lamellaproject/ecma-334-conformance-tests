/*
Rules: E7-3-alias-declaration-space; E7-3-using-alias-declaration
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: using Slot = System.String;
Into: using Slot = System.Int32;
*/
using System;
namespace Left
{
    using Slot = System.Int32;
    class Value { public static Slot Read() { return 37; } }
}
namespace Right
{
    using Slot = System.String;
    class Value { public static Slot Read() { return "twig"; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Left.Value.Read() == 37, "left-namespace-alias");
        Check(Right.Value.Read() == "twig", "right-namespace-alias");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
