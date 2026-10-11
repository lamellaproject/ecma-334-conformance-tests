/*
Rules: E7-3-namespace-nesting; E7-3-declaration-name; E7-3-type-declaration-categories; E7-4-1-member-bearing-entities; E7-4-2-global-namespace-members; E7-4-2-declared-namespace-members
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: namespace Leaf
Into: namespace Renamed
*/
using System;
namespace Grove
{
    namespace Leaf { public class Item { public static int Value = 17; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Grove.Leaf.Item.Value == 17, "type-in-nested-namespace");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
