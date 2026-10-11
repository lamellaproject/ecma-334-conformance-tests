/*
Rules: E7-3-repeated-namespace; E7-3-namespace-aggregation
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Later
Into: class Renamed
*/
using System;
namespace Grove { class Earlier { public static int Read() { return Later.Value; } } }
namespace Grove { class Later { public const int Value = 53; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Grove.Earlier.Read() == 53, "same-namespace-merged");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
