/*
Rules: E7-8-1-qualified-nested-namespace; E7-8-1-qualified-namespace-type; E7-8-1-name-form-qualified
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Orchard.Grove.Fruit item = new Orchard.Grove.Fruit();
Into: Orchard.Grove<int>.Fruit item = new Orchard.Grove<int>.Fruit();
*/
using System;
namespace Orchard
{
    namespace Grove { public class Fruit { public int Value = 113; } }
    public class Grove<T> { public class Fruit { public int Value = 127; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Orchard.Grove.Fruit item = new Orchard.Grove.Fruit();
        Check(item.Value == 113, "arity-zero-selects-nested-namespace");
        Check(new Orchard.Grove<int>.Fruit().Value == 127, "explicit-arity-selects-namespace-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
