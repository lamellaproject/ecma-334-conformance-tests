/*
Rules: E7-8-1-qualified-namespace-type
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Orchard.Fruit<int> item = new Orchard.Fruit<int>();
Into: Orchard.Fruit<long> item = new Orchard.Fruit<long>();
*/
using System;
namespace Orchard { public class Fruit<T> { public T Value; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Orchard.Fruit<int> item = new Orchard.Fruit<int>(); item.Value = 131;
        Check((object)item is Orchard.Fruit<int>, "namespace-type-constructed-with-supplied-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
