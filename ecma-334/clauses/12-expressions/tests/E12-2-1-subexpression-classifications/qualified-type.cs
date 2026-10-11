/*
Rules: E12-2-1-subexpression-classifications
Authority: ECMA-334 7th ed 12.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Shade.Box.Value
Into: Shade.Box
*/
using System;
namespace Shade { class Box { public static int Value = 37; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int result = Shade.Box.Value;
        Check(result == 37, "namespace-type-subexpressions");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
