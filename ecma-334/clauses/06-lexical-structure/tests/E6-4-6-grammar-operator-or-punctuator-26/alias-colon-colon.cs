/*
Rules: E6-4-6-grammar-operator-or-punctuator-26
Authority: ECMA-334 7th ed 6.4.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Area::Node.Value
Into: Area:Node.Value
*/
using System;
using Area = Region;
namespace Region { class Node { public static int Value = 43; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int result = Area::Node.Value;
        Check(result == 43, "double-colon");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
