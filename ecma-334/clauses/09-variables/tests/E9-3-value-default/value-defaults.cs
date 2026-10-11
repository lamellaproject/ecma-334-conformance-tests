/*
Rules: E9-3-value-default
Authority: ECMA-334 7th ed 9.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: static Pair pair;
Into: static Pair pair = new Pair { Number = 8 };
*/
using System;
struct Pair { public int Number; public object Reference; }
enum Flag : short { Named = 9 }
class Program
{
    static int checks, failures;
    static Pair pair;
    static Flag flag;
    static int? nullable;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Pair constructed = new Pair();
        Check(pair.Number == constructed.Number && pair.Reference == constructed.Reference, "struct-default-constructor-value");
        Check(flag == new Flag() && (short)flag == 0, "enum-default-constructor-value");
        Check(nullable.HasValue == new int?().HasValue && !nullable.HasValue, "nullable-default-constructor-value");
        int[] values = new int[1];
        Check(values[0] == new int(), "primitive-default-constructor-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
