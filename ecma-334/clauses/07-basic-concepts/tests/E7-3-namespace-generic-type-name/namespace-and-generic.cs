/*
Rules: E7-3-namespace-generic-type-name
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: class Branch<T>
Into: class Branch
*/
using System;
namespace Branch { class Item { public const int Value = 17; } }
class Branch<T> { public const int Value = 19; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Branch.Item.Value == 17, "namespace-name");
        Check(Branch<int>.Value == 19, "same-name-generic-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
