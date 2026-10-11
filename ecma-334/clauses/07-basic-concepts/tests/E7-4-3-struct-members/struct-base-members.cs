/*
Rules: E7-4-3-struct-members; E7-5-2-struct-implicitly-sealed
Authority: ECMA-334 7th ed 7.4.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: struct Pair
Into: class Pair
*/
using System;
struct Pair { public int Number; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Pair first = new Pair { Number = 17 }, second = new Pair { Number = 17 };
        Check(first.Equals(second), "inherited-value-type-equals");
        Check(first.GetType() == typeof(Pair), "inherited-object-get-type");
        Check(typeof(Pair).BaseType == typeof(ValueType) && typeof(Pair).IsSealed, "struct-base-and-sealing");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
