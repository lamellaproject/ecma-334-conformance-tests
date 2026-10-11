/*
Rules: E7-8-1-alias-resolution
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: using Fruit = East.Fruit;
Into: using Fruit = West.Fruit;
*/
using System;
using West;
using Fruit = East.Fruit;
namespace East { class Fruit { public int Value = 97; } }
namespace West { class Fruit { public int Value = 95; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Fruit item = new Fruit();
        Check(item.Value == 97, "type-alias-precedes-imported-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
