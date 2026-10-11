/*
Rules: E6-4-4-grammar-keyword-40; E6-4-4-grammar-keyword-73; E6-4-4-grammar-keyword-36
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: namespace Cargo
Into: module Cargo
*/
using System;
using Cargo;
namespace Cargo { internal class Counter { public static int Value = 61; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Counter.Value == 61, "namespace-import");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
